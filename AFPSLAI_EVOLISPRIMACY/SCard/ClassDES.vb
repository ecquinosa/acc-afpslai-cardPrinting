Public Class ClassDES

    Public Const ALGO_DES As Short = 0
    Public Const ALGO_3DES As Short = 1
    Public Const ALGO_XOR As Short = 3
    Public Const DATA_ENCRYPT As Short = 1
    Public Const DATA_DECRYPT As Short = 2

    Public Declare Function Chain_DES Lib "chaindes.dll" (ByRef Data As Byte, ByRef key As Byte, ByVal TripleDES As Short, ByVal Blocks As Integer, ByVal method As Integer) As Integer

    Public Declare Function Chain_MAC Lib "chaindes.dll" (ByRef mac As Byte, ByRef Data As Byte, ByRef key As Byte, ByVal Blocks As Integer) As Integer

    Public Declare Function Chain_MAC2 Lib "chaindes.dll" (ByRef mac As Byte, ByRef Data As Byte, ByRef key As Byte, ByVal Blocks As Integer) As Integer

End Class
