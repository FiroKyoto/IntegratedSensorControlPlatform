#pragma once


// CLrf dialog

class CLrf : public CDialog
{
	DECLARE_DYNAMIC(CLrf)

public:
	CLrf(CWnd* pParent = NULL);   // standard constructor
	virtual ~CLrf();

// Dialog Data
	enum { IDD = IDD_LRF_DIALOG };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
};
