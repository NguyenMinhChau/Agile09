/**
 * @license Copyright (c) 2003-2021, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
	config.extraPlugins = 'syntaxhighlight';
	config.syntaxhighlight_lang = 'csharp';
	config.syntaxhighlight_hideControls = true;
	config.language = 'vi';
	config.filebrowserBrowseUrl = '/Asset/admin/js/plugin1/ckfinder/ckfinder.html';
	config.filebrowserImageBrowseUrl = '/Asset/admin/js/plugin1/ckfinder/ckfinder.html?Type=Images';
	config.filebrowserFlashBrowseUrl = '/Asset/admin/js/plugin1/ckfinder/ckfinder.html?Type=Flash';
	config.filebrowserUploadUrl = '/Asset/admin/js/plugin1/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
	config.filebrowserImageUploadUrl = '/Photos';
	config.filebrowserFlashUploadUrl = '/Asset/admin/js/plugin1/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
	//CKFinder.setupCKEditor(null, '/Asset/admin/js/plugin1/ckfinder/')
};
