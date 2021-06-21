Public Class SharedFunction

    Private Shared Function requestCredential() As [Class].requestCredential
        Dim cred As [Class].requestCredential = New [Class].requestCredential()
        cred.dateRequest = DateTime.Now.ToString()
        cred.key = Properties.Settings.[Default].ApiKey
        cred.userId = DataCapture.dcsUser.userId
        cred.userName = DataCapture.dcsUser.userName
        cred.userPass = DataCapture.dcsUser.userPass
        cred.branch = Properties.Settings.[Default].BranchIssue
        Return cred
    End Function

    Private Shared Function requestPayload(ByVal payload As String) As [Class].requestPayload
        Dim reqPayload As [Class].requestPayload = New [Class].requestPayload()
        reqPayload.authentication = accAfpslaiEmvEncDec.Aes256CbcEncrypter.Encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(requestCredential()))
        reqPayload.payload = payload
        Return reqPayload
    End Function

    Public Shared Function ExecuteApiRequest(ByVal url As String, ByVal soapStr As String, ByRef soapResponse As String, ByRef err As String) As Boolean
        Dim myHttpWebRequest As System.Net.HttpWebRequest = CType(System.Net.WebRequest.Create(url), System.Net.HttpWebRequest)
        Dim client As System.Net.Http.HttpClient = New System.Net.Http.HttpClient()

        Try
            Dim uri = New Uri(url)
            Dim baseUrl As String = String.Format("http://{0}", uri.Authority)
            If url.Contains("https://") Then baseUrl = String.Format("https://{0}", uri.Authority)
            Dim otherUrl As String = uri.LocalPath
            client.BaseAddress = New Uri(baseUrl)
            client.DefaultRequestHeaders.Accept.Add(New System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"))
            Dim buffer = System.Text.Encoding.UTF8.GetBytes(soapStr)
            Dim byteContent = New System.Net.Http.ByteArrayContent(buffer)
            byteContent.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
            byteContent.Headers.ContentLength = buffer.Length
            Dim response As System.Net.Http.HttpResponseMessage = client.PostAsync(otherUrl, byteContent).Result

            If response.IsSuccessStatusCode Then
                soapResponse = response.Content.ReadAsStringAsync().Result
                Return True
            Else
                err = String.Format("{0} {1}", response.StatusCode, response.ReasonPhrase)
                Return False
            End If

        Catch ex As Exception

            If ex.Message.Equals("One or more errors occurred.") Then
                err = "Unable to reach middle server api."
            Else
                err = ex.Message
            End If

            Return False
        Finally
            client.Dispose()
            myHttpWebRequest = Nothing
        End Try
    End Function

End Class
