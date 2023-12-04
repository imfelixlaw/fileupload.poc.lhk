<?php
//ezSQL Setting, mySQL only
define("_DB_HOST_ADDRESS", "localhost");
define("_DB_HOST_USERNAME", "root");
define("_DB_HOST_PASSWORD", "mis093@lhk");
define("_DB_HOST_DBNAME", "cms");

//password key
define("_PASSWORD_ENCRYPTION_KEY", "This is a password protected key");

//database setting
define("_DB_USR_USER", "usr_user");
define("_DB_USR_ROLE", "usr_role");
define("_DB_USR_MOD_ACCESS", "usr_moduleroleaccess");
 

//general setting
define("_GEN_REQ_LOGIN", true);//require login
define("_GEN_OPEN_REG", false);//true, open register to all visitor, false, admin only
define("_GEN_DEBUG_MODE", false);//debug message is show
define("_GEN_RUN_MODE", true); //system is running

define("_SYSTEM_NAME", "Simple CMS"); //system name

//main module path
define("_MAIN_CORE", "mod_user");

//path setting -- don't simply modified
define("_PATH_LIBS", "../libs");

//Action
define("_JS_ACTION_CLOSE", "javascript:window.close();");
define("_JS_ACTION_BACK", "mod_user");

define("_ALL", "All");
define("_GROUP", "Group");
define("_OWN", "Own");
define("_READ", "Read");
define("_WRITE", "Write");
define("_ACTIVE", "Active");
define("_BANNED", "Banned");
define("_DELETED", "Deleted");
define("_OTHER", "Other");
define("_Y", "Y");
define("_N", "N");
?>
