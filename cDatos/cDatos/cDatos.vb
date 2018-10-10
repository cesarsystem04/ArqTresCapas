
'Sistema  : cDatos 
'Módulo   : Datos 
'Author   : CTG - César Torres García- 08/Febrero/2017 
'Objetivo : Generar modulo de datos generico
'versión  : 1.0.0 
'Historico: 

Public Class cDatos

    Private _msgError As String
    Private _bolExito As Boolean
    Private _strCadenaConexion As String = ""
    Private _strVersion As String = "1.0.0.0"

#Region "Propiedades"
    ''' <summary>
        ''' Para manejar los mensajes de error
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>CTG - - 08/Feb/2017</remarks>
    Public ReadOnly Property msgError() As String
        Get
            Return _msgError
        End Get
    End Property


    ''' <summary>
    ''' Indica si el proceso tuvo exito
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>CTG - - 08/Feb/2017</remarks>
    Public ReadOnly Property bolExito() As Boolean
        Get
            Return _bolExito
        End Get
    End Property


    ''' <summary>
    ''' Establece o leé la Cadena de Conexión
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>CTG - - 08/Feb/2017</remarks>
    Public Property strCadenaConexion() As String
        Get
            Return _strCadenaConexion
        End Get
        Set(ByVal value As String)
            _strCadenaConexion = value
        End Set
    End Property


    ''' <summary>
    ''' Establece la versión del nucleo de la capa de datos 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>CTG - - 08/Feb/2017</remarks> 
    Public ReadOnly Property strVersion() As String
        Get
            Return _strVersion
        End Get
    End Property


#End Region


    ''' <summary> 
        ''' Ejecuta una cadena SQL en la base de datos SQL Server 
        ''' </summary> 
        ''' <param name="strSentencia">Consulta SQL o SP</param> 
        ''' <returns></returns> 
       ''' <remarks>CTG - - 08/Feb/2017</remarks>
    Public Function EjecutaConsultaSQLServer(ByVal strSentencia As String) As DataSet
        Dim dstDatos As New DataSet
        Dim dapDatos As New SqlClient.SqlDataAdapter
        Dim objConn As New SqlClient.SqlConnection(CadenaConexion)

        'Inicializamos los mensajes de error 
        _msgError = ""
        _bolExito = True
        Try
            'Ejecutamos la sentencia 
            dapDatos.SelectCommand = New SqlClient.SqlCommand(ValidaInyeccionCodigo(strSentencia), objConn)

            'Obtenemos los datos 
            dapDatos.Fill(dstDatos)
            _bolExito = True
        Catch ex As Exception
            'Si hay un error lo cachamos 
            _msgError = ex.Message
            _bolExito = False
        Finally
            'Liberamos los objetos 
            objConn.Close()
            objConn.Dispose()
            dapDatos.Dispose()

        End Try
        Return dstDatos
    End Function


    ''' <summary>
    ''' Elimina posible sentencias de SQL por Inyeccion de codigo
    ''' </summary>
    ''' <param name="strSQL">Cadena SQL a validar</param>
    ''' <returns></returns>
    ''' <remarks>CTG - - 08/Feb/2017</remarks>
    ''' 
    Private Function ValidaInyeccionCodigo(ByVal strSQL As String) As String
        Dim strCadenaLimpia As String = ""
        Dim intIndice As Int16 = -1
        Dim intLongitud As Int16 = 0
        Dim strCadenaSemiLimpia As String = ""

        strCadenaLimpia = strSQL

        With strSQL.ToUpper()

            If .IndexOf("DROP", 0) > -1 Then 'Borrado de tablas
                intIndice = .IndexOf("DROP", 0)
                intLongitud = intIndice + 4

            ElseIf .IndexOf("TRUNCATE", 0) > -1 Then 'Limpieza o eliminacion de tablas

                intIndice = .IndexOf("TRUNCATE", 0)
                intLongitud = intIndice + 8

            ElseIf .IndexOf("DELETE", 0) > -1 Then 'Limpieza o eliminacion de Datos

                intIndice = .IndexOf("DELETE", 0)
                intLongitud = intIndice + 6

            ElseIf .IndexOf("/*", 0) > -1 Then 'Anulacion de codigo

                intIndice = .IndexOf("/*", 0)
                intLongitud = intIndice + 2

            ElseIf .IndexOf("--", 0) > -1 Then 'Anulacion de codigo

                intIndice = .IndexOf("--", 0)
                intLongitud = intIndice + 2

            ElseIf .IndexOf("INSERT", 0) > -1 Then 'Insercion de datos

                intIndice = .IndexOf("INSERT", 0)
                intLongitud = intIndice + 6

            ElseIf .IndexOf("CREATE", 0) > -1 Then 'Creacion de tablas o Campos

                intIndice = .IndexOf("CREATE", 0)
                intLongitud = intIndice + 6

            ElseIf .IndexOf("EXEC", 0) > -1 Then 'Ejecucion de SP's de sistema

                intIndice = .IndexOf("EXEC ", 0)
                intLongitud = intIndice + 5

            ElseIf .IndexOf("UPDATE", 0) > -1 Then 'Actualizacion de datos

                intIndice = .IndexOf("UPDATE", 0)
                intLongitud = intIndice + 6

            End If

        End With


        If intIndice > -1 Then
            strCadenaSemiLimpia = strSQL.Substring(0, intIndice) & strSQL.Substring(intLongitud, strSQL.Length - (intLongitud))
            strCadenaLimpia = ValidaInyeccionCodigo(strCadenaSemiLimpia)
        End If

        Return strCadenaLimpia
    End Function

    ''' <summary>
    ''' Determina la Cadena de conexión
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>CTG - - 08/Feb/2017</remarks>
    Private Function CadenaConexion() As String
        Dim strAmbiente As String = ""

        strAmbiente = System.Configuration.ConfigurationManager.AppSettings("Ambiente").ToString()

        Select Case strAmbiente
            Case "Produccion"
                _strCadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings("BaseProduccion").ToString()

            Case "Desarrollo"
                _strCadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings("BaseDesarrollo").ToString()

        End Select



        Return _strCadenaConexion
    End Function

End Class
