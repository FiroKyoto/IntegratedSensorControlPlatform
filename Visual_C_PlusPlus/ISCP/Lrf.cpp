// Lrf.cpp : implementation file
//

#include "stdafx.h"
#include "ISCP.h"
#include "Lrf.h"
#include "afxdialogex.h"


// CLrf dialog

IMPLEMENT_DYNAMIC(CLrf, CDialog)

CLrf::CLrf(CWnd* pParent /*=NULL*/)
	: CDialog(CLrf::IDD, pParent)
{

}

CLrf::~CLrf()
{
}

void CLrf::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CLrf, CDialog)
END_MESSAGE_MAP()


// CLrf message handlers
