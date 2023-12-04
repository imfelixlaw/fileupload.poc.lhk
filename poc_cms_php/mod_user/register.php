<?php
$_root_path = "../";

require_once($_root_path."common.php");
if( constant("_GEN_OPEN_REG") == false )
{
	$smarty
		->assign("Name", constant("_SYSTEM_NAME"), true)
		->assign("Error_Message", "No Permission!!!")
		->assign("Action", constant("_JS_ACTION_CLOSE"))
		->assign("ButtonName", "Close!!!")
		->display('error.tpl');
	exit;
}
?>