// Setting.cpp : implementation file
//

#include "stdafx.h"
#include "ISCP.h"
#include "Setting.h"
#include "afxdialogex.h"


// CSetting dialog

IMPLEMENT_DYNAMIC(CSetting, CDialog)

CSetting::CSetting(CWnd* pParent /*=NULL*/)
	: CDialog(CSetting::IDD, pParent)
{

}

CSetting::~CSetting()
{
}

void CSetting::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LRF_IS_RUN_CHECK, m_LrfIsRunCheck);
	DDX_Control(pDX, IDC_LRF_IP_ADD_EDIT, m_LrfIpAddEdit);
	DDX_Control(pDX, IDC_LRF_TCP_PORT_EDIT, m_LrfTcpPortEdit);
	DDX_Control(pDX, IDC_LRF_SCALING_FACTOR_EDIT, m_LrfScalingFactorEdit);
	DDX_Control(pDX, IDC_SELECT_DEVICE_COMBO, m_LrfSelectDeviceCombo);
	DDX_Control(pDX, IDC_BODY_IS_RUN_CHECK, m_BodyIsRunCheck);
	DDX_Control(pDX, IDC_LRF_SAVE_CHECK, m_LrfSaveCheck);
	DDX_Control(pDX, IDC_LRF_READ_CHECK, m_LrfReadCheck);
	DDX_Control(pDX, IDC_LRF_GL_CHECK, m_LrfGlCheck);
}


BEGIN_MESSAGE_MAP(CSetting, CDialog)
END_MESSAGE_MAP()


// CSetting message handlers
