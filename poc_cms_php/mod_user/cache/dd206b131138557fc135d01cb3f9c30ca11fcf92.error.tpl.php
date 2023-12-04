<?php /*%%SmartyHeaderCode:315444ef17d3a296233-30148717%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'dd206b131138557fc135d01cb3f9c30ca11fcf92' => 
    array (
      0 => '.\\templates\\error.tpl',
      1 => 1324448864,
      2 => 'file',
    ),
    '10e0737838b4a574ef135d0c601e7b602cfaf37a' => 
    array (
      0 => '.\\templates\\header.tpl',
      1 => 1324332014,
      2 => 'file',
    ),
    '1be7ff7fdee636597edd726ee98dfef4bfd55d1f' => 
    array (
      0 => '.\\templates\\footer.tpl',
      1 => 1324332014,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '315444ef17d3a296233-30148717',
  'variables' => 
  array (
    'Error_Message' => 0,
    'Action' => 0,
    'ButtonName' => 0,
  ),
  'has_nocache_code' => true,
  'version' => 'Smarty-3.1.7',
  'unifunc' => 'content_4ef17d3a3a8c0',
  'cache_lifetime' => 120,
),true); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_4ef17d3a3a8c0')) {function content_4ef17d3a3a8c0($_smarty_tpl) {?><HTML>
<HEAD>
<TITLE>System Error - <?php echo $_smarty_tpl->tpl_vars['Name']->value;?>
</TITLE>
</HEAD>
<BODY bgcolor="#ffffff">

<table border="1" width="600" align="center">
<tr><th>Error Message</th></tr>
<tr><td>No Permission!!!</td></tr>
<tr><td align="center"><input onclick="javascript:window.close();" value="Close!!!" type="Button"></td></tr>
</table>
</BODY>
</HTML>

<?php }} ?>