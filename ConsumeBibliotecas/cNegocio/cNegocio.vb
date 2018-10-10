'Sistema  : cNegocio 
'Módulo   : Capa de Negocio 
'Author   : CTG - César Torres García- 08/Febrero/2017 
'Objetivo : Contiene todas las reglas de negocio
'versión  : 1.0.0 
'Historico: 

Imports cDatos
Imports System.IO
Imports System.IO.Stream



Public Class cNegocio

    Private _msgError As String = ""
    Private _bolExito As Boolean = True
    Private _strVersion As String = "1.0.0.0"
    Private _objDatos As New cDatos.cDatos

#Region "Propiedades"
    ''' <summary>
    ''' Manejo de mensajes de error
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property msgError() As String
        Get
            Return _msgError
        End Get
    End Property

    ''' <summary>
    ''' Indica si el Proceso tuvo exito
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property bolExito As Boolean
        Get
            Return _bolExito
        End Get
    End Property

    ''' <summary>
    ''' Indica la versión de la capa de negocio
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property strVersion As String
        Get
            Return _strVersion
        End Get
    End Property

#End Region



    ''' <summary>
    ''' Devuelve listado de Usuario
    ''' </summary>
    ''' <returns></returns>
    Public Function Usuario_Listado() As DataSet
        Dim dstDatos As New DataSet
        Dim strSQL As String = ""


        _msgError = ""
        _bolExito = True

        Try
            strSQL = "SIAD_SP_Usuarios_Listado"
            dstDatos = _objDatos.EjecutaConsultaSQLServer(strSQL)
            _objDatos.strCadenaConexion() = "hola"

        Catch ex As Exception

            _msgError = ex.Message
            _bolExito = False

        End Try
        Return dstDatos
    End Function


    ''' <summary>
    ''' Agrega el registro de un nuevo usuario
    ''' </summary>
    ''' <param name="strUserId">Id usuario</param>
    ''' <param name="strNombreIntegrante">Nombre completo del usuario</param>
    ''' <param name="strUbicacion">Ubicacion departamento al cual pertenece</param>
    ''' <param name="strTelefono">Telefono del Usuario</param>
    ''' <param name="strExtension">Extensión del Usuario</param>
    ''' <param name="strCorreoElectronico">Correo electronico del usuario</param>
    ''' <param name="strPuesto">Puesto del Usuario</param>
    ''' <param name="strResponsabilidad">Responsabilidad</param>
    ''' <param name="strOrganizacion">Organización</param>
    ''' <param name="strPerfil">Perfil del Usuario</param>
    ''' <returns></returns>
    Public Function Usuario_Guarda(strUserId As String,
                                 strNombreIntegrante As String,
                                 strUbicacion As String,
                                 strTelefono As String,
                                 strExtension As String,
                                 strCorreoElectronico As String,
                                 strPuesto As String,
                                 strResponsabilidad As String,
                                 strOrganizacion As String,
                                 strPerfil As String) As DataSet
        Dim dstDatos As New DataSet
        Dim strSQL As String = ""


        _msgError = ""
        _bolExito = True


        Try

            strSQL = "SIAD_SP_Usuario_Guarda '" & strUserId & "'" &
                                         ",'" & strNombreIntegrante & "'" &
                                         ",'" & strUbicacion & "'" &
                                         ",'" & strTelefono & "'" &
                                         ",'" & strExtension & "'" &
                                         ",'" & strCorreoElectronico & "'" &
                                         ",'" & strPuesto & "'" &
                                         ",'" & strResponsabilidad & "'" &
                                         ",'" & strOrganizacion & "'" &
                                         ",'" & strPerfil & "'"


            dstDatos = _objDatos.EjecutaConsultaSQLServer(strSQL)

        Catch ex As Exception

            _msgError = ex.Message
            _bolExito = False

        End Try



        Return dstDatos
    End Function



    ''' <summary>
    ''' Elimina el registro de un Usuario
    ''' </summary>
    ''' <param name="strUserId"></param>
    ''' <returns></returns>
    Public Function Usuario_Elimina(strUserId As String) As DataSet

        Dim dstDatos As New DataSet
        Dim strSQL As String = ""


        _msgError = ""
        _bolExito = True


        Try
            strSQL = "SIAD_SP_Usuario_Elimina'" & strUserId & "'"

            dstDatos = _objDatos.EjecutaConsultaSQLServer(strSQL)

        Catch ex As Exception

            _msgError = ex.Message
            _bolExito = False

        End Try




        Return dstDatos
    End Function



    ''' <summary>
    ''' Consulta el registro de un Usuario
    ''' </summary>
    ''' <param name="strUserId"></param>
    ''' <returns></returns>
    Public Function Usuario_Consulta(strUserId As String) As DataSet

        Dim dstDatos As New DataSet
        Dim strSQL As String = ""


        _msgError = ""
        _bolExito = True


        Try
            strSQL = "SIAD_SP_Usuario_Consulta'" & strUserId & "'"

            dstDatos = _objDatos.EjecutaConsultaSQLServer(strSQL)

        Catch ex As Exception

            _msgError = ex.Message
            _bolExito = False
        End Try

        Return dstDatos
    End Function


    Public Function CrearArchivo(strContenido As String, strRutaArchivo As String, bolSobrescribir As Boolean) As Boolean

        Dim objArchivo As StreamWriter
        Dim objEncode As New System.Text.UTF8Encoding
        _msgError = ""
        _bolExito = True

        objArchivo = New StreamWriter(strRutaArchivo, bolSobrescribir, objEncode)

        Try

            objArchivo.Write(strContenido)

        Catch ex As Exception

            _msgError = ex.Message
            _bolExito = False

        Finally
            objArchivo.Close()

        End Try

        Return _bolExito

    End Function

End Class
