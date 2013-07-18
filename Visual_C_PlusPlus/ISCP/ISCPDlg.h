
// ISCPDlg.h : header file
//

#pragma once
#include "afxcmn.h"
#include "Setting.h"
#include "Lrf.h"
#include "Vy446.h"
#include "afxwin.h"


// CISCPDlg dialog
class CISCPDlg : public CDialogEx
{
// Construction
public:
	CISCPDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_ISCP_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
private:
	void InitializeTabCtrl();
	void InitializeSetVariable();
	void TimerDebug();

	CSetting m_Setting_Tab;
	CLrf m_Lrf_Tab;
	CVy446 m_Vy446_Tab;

	// save the pointer of window of current view frame
	CWnd* m_pwndShow;

	int readCnt;
	CString readCountStr;

protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	CTabCtrl m_mainTabCtrl;
	afx_msg void OnTcnSelchangeTab1(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnBnClickedConnectButton();
	afx_msg void OnBnClickedExitButton();
	afx_msg void OnBnClickedDisconnectButton();
	CEdit m_readCountEdit;
	afx_msg void OnTimer(UINT_PTR nIDEvent);
};
