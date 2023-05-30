/*
Copyright (c) 2003-2014, CKSource - Frederico Knabben. All rights reserved.
For licensing, see license.txt or http://cksource.com/ckfinder/license
*/

CKFinder.customConfig = function (config) {
    // Define changes to default configuration here.
    // For the list of available options, check:
    // http://docs.cksource.com/ckfinder_2.x_api/symbols/CKFinder.config.html

    // Sample configuration options:
    // config.uiColor = '#BDE31E';
    // config.language = 'fr';
    // config.removePlugins = 'basket';
    config.LicenseName = 'servidor2010';
    config.LicenseKey = 'XXX-XXX-etc';

    //CKFinder.config.customConfig = baseUrl + '/ckfinder/config.js';

    //config.filebrowserBrowseUrl = baseUrl;
    //config.filebrowserImageBrowseUrl = baseUrl;
    //config.filebrowserFlashBrowseUrl = baseUrl;
    //config.filebrowserUploadUrl = baseUrl;
    //config.filebrowserImageUploadUrl = baseUrl;
    //config.filebrowserFlashUploadUrl = baseUrl;


    config.filebrowserBrowseUrl = 'ckeditor/ckfinder/ckfinder.html',
    config.filebrowserImageBrowseUrl = 'ckeditor/ckfinder/ckfinder.html?type=Images',
    config.filebrowserFlashBrowseUrl = 'ckeditor/ckfinder/ckfinder.html?type=Flash',
    config.filebrowserUploadUrl = 'ckeditor/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Fil­es',
    config.filebrowserImageUploadUrl = 'ckeditor/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Ima­ges',
    config.filebrowserFlashUploadUrl = 'ckeditor/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Fla­sh'


};

//CKEDITOR.replace('editor1',
//{
//    filebrowserBrowseUrl: '/ckfinder/ckfinder.html',
//    filebrowserImageBrowseUrl: '/ckfinder/ckfinder.html?type=Images',
//    filebrowserFlashBrowseUrl: '/ckfinder/ckfinder.html?type=Flash',
//    filebrowserUploadUrl: '/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Files',
//    filebrowserImageUploadUrl: '/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Images',
//    filebrowserFlashUploadUrl: '/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Flash',
//    filebrowserWindowWidth: '1000',
//    filebrowserWindowHeight: '700'
//});
