Imports VNN_WEBEXTRACTOR

Public Class VNN_WEBEXTRACTSVC
    Inherits System.ServiceProcess.ServiceBase

#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        ' This call is required by the Component Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call

    End Sub

    'UserService overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' The main entry point for the process
    <MTAThread()> _
    Shared Sub Main()
        Dim ServicesToRun() As System.ServiceProcess.ServiceBase

        ' More than one NT Service may run within the same process. To add
        ' another service to this process, change the following line to
        ' create a second service object. For example,
        '
        '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
        '
        ServicesToRun = New System.ServiceProcess.ServiceBase() {New VNN_WEBEXTRACTSVC}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  
    ' Do not modify it using the code editor.
    Friend WithEvents Timer1 As System.Timers.Timer
    Friend WithEvents EventLog1 As System.Diagnostics.EventLog

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Timer1 = New System.Timers.Timer
        Me.EventLog1 = New System.Diagnostics.EventLog
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Timer1
        '
        Me.Timer1.Interval = 60000
        '
        'VNN_WEBEXTRACTSVC
        '
        Me.CanPauseAndContinue = True
        Me.CanShutdown = True
        Me.ServiceName = "VNN_WEBEXTRACTSVC"
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        Dim objReg As New VNN_WEBEXTRACTOR.MyRegistry
        objReg.getRegs()

        If objReg.intTimeInterval.ToString <> "" Then
            Timer1.Interval = objReg.intTimeInterval * 60000
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

        objReg = Nothing
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        Timer1.Enabled = False
    End Sub

    Private Sub Timer1_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) _
        Handles Timer1.Elapsed
        If Not EventLog1.SourceExists("VNN_WEBEXTRACTSVC") Then
            EventLog1.CreateEventSource("VNN_WEBEXTRACTSVC", "Application")
        End If
        EventLog1.Source = "VNN_WEBEXTRACTSVC"
        EventLog1.WriteEntry("VNN_WEBEXTRACTSVC START GET INTERNET DATA AT: " & String.Format("{0:s}", DateTime.Now), _
                              EventLogEntryType.Information)
        doExtract()
        EventLog1.Source = "VNN_WEBEXTRACTSVC"
        EventLog1.WriteEntry( _
                              "VNN_WEBEXTRACTSVC FINISHED GET INTERNET DATA AT: " & _
                              String.Format("{0:s}", DateTime.Now), EventLogEntryType.Information)
    End Sub

    Private Sub doExtract()
        Try
            Dim objExtractor As New Extractor
            Dim objConn As New VNN_WEBEXTRACTOR.Connection
            objExtractor.initDataConnection(objConn.getConnection)
            objExtractor.doAutoExtract()
            'objExtractor.doAutoNotNewsExtract()
            objExtractor = Nothing
        Catch ex As Exception
            EventLog1.Source = "VNN_WEBEXTRACTSVC"
            EventLog1.WriteEntry("VNN_WEBEXTRACTSVC, Error: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub
End Class
