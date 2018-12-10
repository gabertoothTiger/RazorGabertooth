// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
	function getModelPrefix(fieldName) {
		return fieldName.substr(0, fieldName.lastIndexOf(".") + 1);
	}

	function escapeAttributeValue(value) {
		return value.replace(/([!"#$%&'()*+,./:;<=>?@\[\\\]^`{|}~])/g, "\\$1");
	} 

	$.validator.addMethod("dategreaterthantoday",
		function (value, element, parameters) {
			var currentDate = new Date().setHours(0, 0, 0, 0),			
				dateToValidate = new Date(value.replace(/-/g, '\/').replace(/T.+/, ''));
			return dateToValidate >= currentDate;
		});

	$.validator.unobtrusive.adapters.add("dategreaterthantoday", [], function (options) {
		options.rules.dategreaterthantoday = {};
		options.messages["dategreaterthantoday"] = options.message;
	});

	$.validator.addMethod("dategreaterthan",
		function (value, element, parameters) {
			var other = new Date(parameters.other.value.replace(/-/g, '\/').replace(/T.+/, '')),
				dateToValidate = new Date(value.replace(/-/g, '\/').replace(/T.+/, ''));
			return dateToValidate > other;
		});

	$.validator.unobtrusive.adapters.add("dategreaterthan", ["other"], function (options) {
		var prefix = getModelPrefix(options.element.name),
			other = options.params.other,
			fullOtherName = prefix + other,
			element = $(options.form).find(":input").filter("[name='" + escapeAttributeValue(fullOtherName) + "']")[0];			

		options.rules["dategreaterthan"] = {
			other: element
		};

		options.messages["dategreaterthan"] = options.message; 
	});
});
