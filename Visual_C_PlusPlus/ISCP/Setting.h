#pragma once
#include "afxwin.h"


// CSetting dialog

class CSetting : public CDialog
{
	DECLARE_DYNAMIC(CSetting)

public:
	CSetting(CWnd* pParent = NULL);   // standard constructor
	virtual ~CSetting();

// Dialog Data
	enum { IDD = IDD_SETTING_DIALOG };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	CButton m_LrfIsRunCheck;
	CEdit m_LrfIpAddEdit;
	CEdit m_LrfTcpPortEdit;
	CEdit m_LrfScalingFactorEdit;
	CComboBox m_LrfSelectDeviceCombo;
	CButton m_BodyIsRunCheck;
	CButton m_LrfSaveCheck;
	CButton m_LrfReadCheck;
	CButton m_LrfGlCheck;
};
