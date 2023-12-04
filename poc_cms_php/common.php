<?php
$_root_path = "../";
require_once($_root_path."constant.php");

//Import Smarty Template System
require_once(constant("_PATH_LIBS")."/Smarty.class.php");
$smarty = new Smarty();
//$smarty->force_compile = true;
$smarty->debugging = true;
$smarty->caching = true;
$smarty->cache_lifetime = 120;

// Include ezSQL core
require_once(constant("_PATH_LIBS")."/ez_sql_core.php");
// Include ezSQL database specific component
require_once(constant("_PATH_LIBS")."/ez_sql_mysql.php");
$ezdb = new ezSQL_mysql(constant("_DB_HOST_USERNAME"),constant("_DB_HOST_PASSWORD"),constant("_DB_HOST_DBNAME"),constant("_DB_HOST_ADDRESS"));
?>