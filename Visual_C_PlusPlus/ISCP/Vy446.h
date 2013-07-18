#pragma once


// CVy446 dialog

class CVy446 : public CDialog
{
	DECLARE_DYNAMIC(CVy446)

public:
	CVy446(CWnd* pParent = NULL);   // standard constructor
	virtual ~CVy446();

// Dialog Data
	enum { IDD = IDD_VY446_DIALOG };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
};
