<?php
$_root_path = "../";
include_once($_root_path."common.php");

if(!constant("_GEN_RUN_MODE"))
	exit;

class mod_user_core
{
	function verify_module_access_level($uid)
	{
		global $ezdb;
		$sql = "SELECT b.`AccessLevel`
				FROM `".constant("_DB_USR_USER")."` a
				INNER JOIN `".constant("_DB_USR_MOD_ACCESS")."` b
					ON a.`FKIDRole` = b.`FKIDRole`
				WHERE a.`IDUser` = ".$uid.";";
		return $ezdb->get_results($sql);
	}

	function get_user_access_level($uid)
	{
		global $ezdb;
		$sql = "SELECT `AccessLevel`
				FROM `".constant("_DB_USR_USER")."`
				WHERE `IDUser` = ".$uid.";";
		return $ezdb->get_results($sql);
	}
	
	function get_user_role_point($uid)
	{
		global $ezdb;
		$sql = "SELECT b.`AccessPoint`
				FROM `".constant("_DB_USR_USER")."` a
				INNER JOIN `".constant("_DB_USR_ROLE")."` b ON a.`FKIDRole` = b.`IDRole`
				WHERE b.`ActiveStatus` = `".constant("_Y")."`;";
		return $ezdb->get_results($sql);
	}

	function get_user_access_right($uid)
	{
		global $ezdb;
		$sql = "SELECT `AccessRight`
				FROM `".constant("_DB_USR_USER")."`
				WHERE `IDUser` = ".$uid.";";
		return $ezdb->get_results($sql);
	}
	
	function verify_access_point($uid, $point)
	{
		if( get_user_role_point($uid) >= $point )
		{
			return true;
		}
		else
		{
			return false;
		}	
	}
	function password_encryption($string)
	{
		return base64_encode(mcrypt_encrypt(MCRYPT_RIJNDAEL_256, md5(constant("_PASSWORD_ENCRYPTION_KEY")), $string, MCRYPT_MODE_CBC, md5(md5(constant("_PASSWORD_ENCRYPTION_KEY")))));
	}
	
	function password_decryption($string)
	{
		return rtrim(mcrypt_decrypt(MCRYPT_RIJNDAEL_256, md5(constant("_PASSWORD_ENCRYPTION_KEY")), base64_decode($string), MCRYPT_MODE_CBC, md5(md5(constant("_PASSWORD_ENCRYPTION_KEY")))), "\0");
	}

	function verify_exist_username($username)
	{
		global $ezdb;
		$sql = "SELECT *
				FROM `".constant("_DB_USR_USER")."`
				WHERE `Username` = '".$username."';";
		if( $ezdb->get_results($sql) )
		{
			//exist
			return true;
		}
		else
		{
			//non-exist
			return false;
		}
	}
	
	function verify_username_password($username, $password)
	{
		global $ezdb;
		$sql = "SELECT *
				FROM `".constant("_DB_USR_USER")."`
				WHERE `Username` = '".$username."'
				AND `Password` = '".$this->password_encryption($password)."';";
		if( $ezdb->get_results($sql) )
		{
			//exist
			return true;
		}
		else
		{
			//non-exist
			return false;
		}
	}

	function verify_exist_email($email)
	{
		global $ezdb;
		$sql = "SELECT *
				FROM `".constant("_DB_USR_USER")."`
				WHERE `Email` = '".$email."';";
		if( $ezdb->get_results($sql) )
		{
			//exist
			return true;
		}
		else
		{
			//non-exist
			return false;
		}
	}
}

$mod_user = new mod_user_core;

if($mod_user->verify_exist_email("abc@abc.com"))
echo 'yes';
else
echo 'no';
echo '<br/>';
if($mod_user->verify_username_password('abc123','123'))
echo 'yes';
else
echo 'no';
echo '<br/>';
echo $mod_user->password_encryption('abc123');

echo '<br/>'.$mod_user->verify_module_access_level(1);

echo $mod_user->password_decryption($mod_user->password_encryption('abc123'));

?>