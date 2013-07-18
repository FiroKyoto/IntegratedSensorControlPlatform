
// ISCPDlg.cpp : implementation file
//

#include "stdafx.h"
#include "ISCP.h"
#include "ISCPDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CAboutDlg dialog used for App About

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// CISCPDlg dialog



CISCPDlg::CISCPDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CISCPDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CISCPDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_TAB1, m_mainTabCtrl);
	DDX_Control(pDX, IDC_READ_COUNT_EDIT, m_readCountEdit);
}

BEGIN_MESSAGE_MAP(CISCPDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_NOTIFY(TCN_SELCHANGE, IDC_TAB1, &CISCPDlg::OnTcnSelchangeTab1)
	ON_BN_CLICKED(IDC_CONNECT_BUTTON, &CISCPDlg::OnBnClickedConnectButton)
	ON_BN_CLICKED(IDC_EXIT_BUTTON, &CISCPDlg::OnBnClickedExitButton)
	ON_BN_CLICKED(IDC_DISCONNECT_BUTTON, &CISCPDlg::OnBnClickedDisconnectButton)
	ON_WM_TIMER()
END_MESSAGE_MAP()


// CISCPDlg message handlers

BOOL CISCPDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here
	this->InitializeTabCtrl();
	this->InitializeSetVariable();

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CISCPDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CISCPDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CISCPDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

///////////////////////////////////////////////////////////////////////////////////
// Region - Tab Control Part
///////////////////////////////////////////////////////////////////////////////////

// 2013-07-18 by wonjae cho
// initialization of main tab
void CISCPDlg::InitializeTabCtrl()
{
	//UpdateData(TRUE);

	CString strTab = _T("");
	strTab.Format(_T("Setting"));
	this->m_mainTabCtrl.InsertItem(0, strTab, 0);
	strTab.Format(_T("LRF"));
	this->m_mainTabCtrl.InsertItem(1, strTab, 0);
	strTab.Format(_T("VY446"));
	this->m_mainTabCtrl.InsertItem(2, strTab, 0);
	//this->m_mainTabCtrl.SetCurSel(0);

	CRect rect;
	this->m_mainTabCtrl.GetClientRect(&rect);
	this->m_Setting_Tab.Create(IDD_SETTING_DIALOG, &this->m_mainTabCtrl);
	this->m_Setting_Tab.SetWindowPos(NULL, 5, 25, rect.Width() - 10, rect.Height() - 30, SWP_SHOWWINDOW | SWP_NOZORDER);

	this->m_Lrf_Tab.Create(IDD_LRF_DIALOG, &this->m_mainTabCtrl);
	this->m_Lrf_Tab.SetWindowPos(NULL, 5, 25, rect.Width() - 10, rect.Height() - 30, SWP_NOZORDER);

	this->m_Vy446_Tab.Create(IDD_VY446_DIALOG, &this->m_mainTabCtrl);
	this->m_Vy446_Tab.SetWindowPos(NULL, 5, 25, rect.Width() - 10, rect.Height() - 30, SWP_NOZORDER);

	this->m_pwndShow = &this->m_Setting_Tab;

	//UpdateData(FALSE);
}

// 2013-07-18 by wonjae cho
// Tab Select change control method
void CISCPDlg::OnTcnSelchangeTab1(NMHDR *pNMHDR, LRESULT *pResult)
{
	// TODO: Add your control notification handler code here
	if(this->m_pwndShow != NULL)
	{
		this->m_pwndShow->ShowWindow(SW_HIDE);
		this->m_pwndShow = NULL;
	}

	int tabIndex = this->m_mainTabCtrl.GetCurSel();

	switch(tabIndex)
	{
	case 0:
		this->m_Setting_Tab.ShowWindow(SW_SHOW);
		this->m_pwndShow = &this->m_Setting_Tab;
		break;

	case 1:
		this->m_Lrf_Tab.ShowWindow(SW_SHOW);
		this->m_pwndShow = &this->m_Lrf_Tab;
		break;

	case 2:
		this->m_Vy446_Tab.ShowWindow(SW_SHOW);
		this->m_pwndShow = &this->m_Vy446_Tab;
		break;
	}

	*pResult = 0;
}

///////////////////////////////////////////////////////////////////////////////////
// End Region - Tab Control Part
///////////////////////////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////////////////////////
// Region - Methods
///////////////////////////////////////////////////////////////////////////////////

// 2013-07-18 by wonjae cho
// Initialization variable for device setting
void CISCPDlg::InitializeSetVariable()
{
	// laser range finder
	this->m_Setting_Tab.m_LrfIsRunCheck.SetCheck(TRUE);
	this->m_Setting_Tab.m_LrfIpAddEdit.SetWindowTextA("192.168.0.1");
	this->m_Setting_Tab.m_LrfTcpPortEdit.SetWindowTextA("2111");
	this->m_Setting_Tab.m_LrfScalingFactorEdit.SetWindowTextA("2");
	this->m_Setting_Tab.m_LrfSelectDeviceCombo.SetCurSel(1);

	// body of combine harvester
	this->m_Setting_Tab.m_BodyIsRunCheck.SetCheck(TRUE);
}

///////////////////////////////////////////////////////////////////////////////////
// End Region - Methods
///////////////////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////////////////////
// Region - Event Handler
///////////////////////////////////////////////////////////////////////////////////

// 2013-07-18 by wonjae cho
// Connect Button Event Handler
void CISCPDlg::OnBnClickedConnectButton()
{
	// TODO: Add your control notification handler code here
	
	// initialization readCnt variable
	this->readCnt = 0;

	// timer set
	this->SetTimer(1, 100, NULL);
}

// 2013-07-18 by wonjae cho
// Disconnect Button Event Handler
void CISCPDlg::OnBnClickedDisconnectButton()
{
	// TODO: Add your control notification handler code here
	
	// timer dispose
	this->KillTimer(1);
}

// 2013-07-18 by wonjae cho
// Exit Button Event Handler
void CISCPDlg::OnBnClickedExitButton()
{
	// TODO: Add your control notification handler code here

	ASSERT(AfxGetMainWnd() != NULL);
	AfxGetMainWnd()->SendMessage(WM_CLOSE);
}

///////////////////////////////////////////////////////////////////////////////////
// End Region - Event Handler
///////////////////////////////////////////////////////////////////////////////////



///////////////////////////////////////////////////////////////////////////////////
// Region - Timer
///////////////////////////////////////////////////////////////////////////////////

// 2013-07-18 by wonjae cho
// OnTimer method
void CISCPDlg::OnTimer(UINT_PTR nIDEvent)
{
	// TODO: Add your message handler code here and/or call default
	
	this->TimerDebug();
	this->readCnt++;

	CDialogEx::OnTimer(nIDEvent);
}

// 2013-07-18 by wonjae cho
// Timer Debug method - read count and processing time 
void CISCPDlg::TimerDebug()
{
	this->readCountStr.Format("%d", this->readCnt);
	this->m_readCountEdit.SetWindowTextA(this->readCountStr);
}

///////////////////////////////////////////////////////////////////////////////////
// End Region - Timer
///////////////////////////////////////////////////////////////////////////////////