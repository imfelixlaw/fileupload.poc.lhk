<?php /* Smarty version Smarty-3.1.7, created on 2011-12-21 07:31:22
         compiled from ".\templates\error.tpl" */ ?>
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
  ),
  'nocache_hash' => '315444ef17d3a296233-30148717',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'Error_Message' => 0,
    'Action' => 0,
    'ButtonName' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.7',
  'unifunc' => 'content_4ef17d3a31c11',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_4ef17d3a31c11')) {function content_4ef17d3a31c11($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 9999, null, array('title'=>"System Error"), 0);?>

<table border="1" width="600" align="center">
<tr><th>Error Message</th></tr>
<tr><td><?php echo $_smarty_tpl->tpl_vars['Error_Message']->value;?>
</td></tr>
<tr><td align="center"><input onclick="<?php echo $_smarty_tpl->tpl_vars['Action']->value;?>
" value="<?php echo $_smarty_tpl->tpl_vars['ButtonName']->value;?>
" type="Button"></td></tr>
</table>
<?php echo $_smarty_tpl->getSubTemplate ("footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 9999, null, array(), 0);?>

<?php }} ?>