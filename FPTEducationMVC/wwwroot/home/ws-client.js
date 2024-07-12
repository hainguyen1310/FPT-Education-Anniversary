/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, {
/******/ 				configurable: false,
/******/ 				enumerable: true,
/******/ 				get: getter
/******/ 			});
/******/ 		}
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "/";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 16);
/******/ })
/************************************************************************/
/******/ ({

/***/ "./resources/components/ws-client/ws-client.js":
/***/ (function(module, exports) {

eval("var url = $('[data-socket-url]').data('socket-url') || false;\nvar id = $('[data-socket-id]').data('socket-id') || false;\nvar time = $('[data-socket-time]').data('socket-time') || false;\nvar hash = $('[data-socket-hash]').data('socket-hash') || false;\n\nif (url && id && time && hash) {\n    var getCount = function getCount(count) {\n        var $notificationTooltips = $('.js-notifications-tooltip'),\n            $notificationDot = $('.js-notification-dot');\n\n        if (parseInt(count) > 0) {\n            $notificationTooltips.each(function () {\n                $(this).removeAttr('style').text(count);\n            });\n            $notificationDot.addClass('is-active');\n        } else {\n            $notificationTooltips.each(function () {\n                $(this).css({\n                    'display': 'none'\n                });\n            });\n            $notificationDot.removeClass('is-active');\n        }\n    };\n\n    var getNotifications = function getNotifications(html) {\n        var $notificationsContainer = $('.notifications').find('.js-notifications-container');\n\n        if ($notificationsContainer.length) {\n            $notificationsContainer.prepend(html[window.userLang]);\n\n            if (typeof kaspersky.unreadCount !== 'undefined') {\n                ++kaspersky.unreadCount;\n            }\n        }\n    };\n\n    var socket = new WebSocket(url);\n\n    socket.onopen = function () {\n        socket.send(JSON.stringify({\n            type: 'join',\n            id: id,\n            time: time,\n            hash: hash\n        }));\n    };\n\n    socket.onmessage = function (message) {\n        var payload = JSON.parse(message.data);\n        getCount(payload.count || 0);\n        getNotifications(payload.html);\n    };\n\n    socket.onclose = console.log;\n    socket.onerror = console.error;\n    window.socket = socket;\n}//# sourceURL=[module]\n//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vLi9yZXNvdXJjZXMvY29tcG9uZW50cy93cy1jbGllbnQvd3MtY2xpZW50LmpzPzhiNjkiXSwibmFtZXMiOlsidXJsIiwiJCIsImlkIiwidGltZSIsImhhc2giLCIkbm90aWZpY2F0aW9uVG9vbHRpcHMiLCIkbm90aWZpY2F0aW9uRG90IiwicGFyc2VJbnQiLCIkbm90aWZpY2F0aW9uc0NvbnRhaW5lciIsImh0bWwiLCJ3aW5kb3ciLCJrYXNwZXJza3kiLCJzb2NrZXQiLCJ0eXBlIiwicGF5bG9hZCIsIkpTT04iLCJtZXNzYWdlIiwiZ2V0Q291bnQiLCJnZXROb3RpZmljYXRpb25zIiwiY29uc29sZSJdLCJtYXBwaW5ncyI6IkFBQUEsSUFBTUEsTUFBTUMsNkNBQVo7QUFDQSxJQUFNQyxLQUFLRCwyQ0FBWDtBQUNBLElBQU1FLE9BQU9GLCtDQUFiO0FBQ0EsSUFBTUcsT0FBT0gsK0NBQWI7O0FBRUEsSUFBSUQscUJBQUosTUFBK0I7QUFBQSxtQkFzQjNCLHlCQUF5QjtBQUNyQixZQUFNSyx3QkFBd0JKLEVBQTlCLDJCQUE4QkEsQ0FBOUI7QUFBQSxZQUNJSyxtQkFBbUJMLEVBRHZCLHNCQUN1QkEsQ0FEdkI7O0FBR0EsWUFBSU0sa0JBQUosR0FBeUI7QUFDckJGLHVDQUEyQixZQUFZO0FBQ25DSjtBQURKSTtBQUdBQztBQUpKLGVBS087QUFDSEQsdUNBQTJCLFlBQVk7QUFDbkNKLDRCQUFZO0FBQ1IsK0JBQVc7QUFESCxpQkFBWkE7QUFESkk7QUFLQUM7QUFDSDtBQXRDc0I7O0FBQUEsMkJBeUMzQixnQ0FBZ0M7QUFDNUIsWUFBTUUsMEJBQTBCUCx5QkFBaEMsNkJBQWdDQSxDQUFoQzs7QUFFQSxZQUFJTyx3QkFBSixRQUFvQztBQUNoQ0EsNENBQWdDQyxLQUFLQyxPQUFyQ0YsUUFBZ0NDLENBQWhDRDs7QUFFQSxnQkFBSSxPQUFPRyxVQUFQLGdCQUFKLGFBQWtEO0FBQzlDLGtCQUFFQSxVQUFGO0FBQ0g7QUFDSjtBQWxEc0I7O0FBQzNCLFFBQU1DLFNBQVMsY0FBZixHQUFlLENBQWY7O0FBRUFBLG9CQUFnQixZQUFNO0FBQ2xCQSxvQkFBWSxlQUFlO0FBQ3ZCQyxrQkFEdUI7QUFFdkJYLGdCQUZ1QjtBQUd2QkMsa0JBSHVCO0FBSXZCQyxrQkFBS0E7QUFKa0IsU0FBZixDQUFaUTtBQURKQTs7QUFTQUEsdUJBQW1CLG1CQUFhO0FBQzVCLFlBQU1FLFVBQVVDLFdBQVdDLFFBQTNCLElBQWdCRCxDQUFoQjtBQUNBRSxpQkFBU0gsaUJBQVRHO0FBQ0FDLHlCQUFpQkosUUFBakJJO0FBSEpOOztBQU1BQSxxQkFBaUJPLFFBQWpCUDtBQUNBQSxxQkFBaUJPLFFBQWpCUDtBQUNBRjtBQWlDSCIsImZpbGUiOiIuL3Jlc291cmNlcy9jb21wb25lbnRzL3dzLWNsaWVudC93cy1jbGllbnQuanMuanMiLCJzb3VyY2VzQ29udGVudCI6WyJjb25zdCB1cmwgPSAkKCdbZGF0YS1zb2NrZXQtdXJsXScpLmRhdGEoJ3NvY2tldC11cmwnKSB8fCBmYWxzZTtcbmNvbnN0IGlkID0gJCgnW2RhdGEtc29ja2V0LWlkXScpLmRhdGEoJ3NvY2tldC1pZCcpIHx8IGZhbHNlO1xuY29uc3QgdGltZSA9ICQoJ1tkYXRhLXNvY2tldC10aW1lXScpLmRhdGEoJ3NvY2tldC10aW1lJykgfHwgZmFsc2U7XG5jb25zdCBoYXNoID0gJCgnW2RhdGEtc29ja2V0LWhhc2hdJykuZGF0YSgnc29ja2V0LWhhc2gnKSB8fCBmYWxzZTtcblxuaWYgKHVybCAmJiBpZCAmJiB0aW1lICYmIGhhc2gpIHtcbiAgICBjb25zdCBzb2NrZXQgPSBuZXcgV2ViU29ja2V0KHVybCk7XG5cbiAgICBzb2NrZXQub25vcGVuID0gKCkgPT4ge1xuICAgICAgICBzb2NrZXQuc2VuZChKU09OLnN0cmluZ2lmeSh7XG4gICAgICAgICAgICB0eXBlOidqb2luJyxcbiAgICAgICAgICAgIGlkOmlkLFxuICAgICAgICAgICAgdGltZTp0aW1lLFxuICAgICAgICAgICAgaGFzaDpoYXNoXG4gICAgICAgIH0pKTtcbiAgICB9O1xuXG4gICAgc29ja2V0Lm9ubWVzc2FnZSA9IChtZXNzYWdlKSA9PiB7XG4gICAgICAgIGNvbnN0IHBheWxvYWQgPSBKU09OLnBhcnNlKG1lc3NhZ2UuZGF0YSk7XG4gICAgICAgIGdldENvdW50KHBheWxvYWQuY291bnQgfHwgMCk7XG4gICAgICAgIGdldE5vdGlmaWNhdGlvbnMocGF5bG9hZC5odG1sKTtcbiAgICB9O1xuXG4gICAgc29ja2V0Lm9uY2xvc2UgPSBjb25zb2xlLmxvZztcbiAgICBzb2NrZXQub25lcnJvciA9IGNvbnNvbGUuZXJyb3I7XG4gICAgd2luZG93LnNvY2tldCA9IHNvY2tldDtcblxuICAgIGZ1bmN0aW9uIGdldENvdW50KGNvdW50KSB7XG4gICAgICAgIGNvbnN0ICRub3RpZmljYXRpb25Ub29sdGlwcyA9ICQoJy5qcy1ub3RpZmljYXRpb25zLXRvb2x0aXAnKSxcbiAgICAgICAgICAgICRub3RpZmljYXRpb25Eb3QgPSAkKCcuanMtbm90aWZpY2F0aW9uLWRvdCcpO1xuXG4gICAgICAgIGlmIChwYXJzZUludChjb3VudCkgPiAwKSB7XG4gICAgICAgICAgICAkbm90aWZpY2F0aW9uVG9vbHRpcHMuZWFjaChmdW5jdGlvbiAoKSB7XG4gICAgICAgICAgICAgICAgJCh0aGlzKS5yZW1vdmVBdHRyKCdzdHlsZScpLnRleHQoY291bnQpO1xuICAgICAgICAgICAgfSk7XG4gICAgICAgICAgICAkbm90aWZpY2F0aW9uRG90LmFkZENsYXNzKCdpcy1hY3RpdmUnKTtcbiAgICAgICAgfSBlbHNlIHtcbiAgICAgICAgICAgICRub3RpZmljYXRpb25Ub29sdGlwcy5lYWNoKGZ1bmN0aW9uICgpIHtcbiAgICAgICAgICAgICAgICAkKHRoaXMpLmNzcyh7XG4gICAgICAgICAgICAgICAgICAgICdkaXNwbGF5JzogJ25vbmUnXG4gICAgICAgICAgICAgICAgfSk7XG4gICAgICAgICAgICB9KTtcbiAgICAgICAgICAgICRub3RpZmljYXRpb25Eb3QucmVtb3ZlQ2xhc3MoJ2lzLWFjdGl2ZScpO1xuICAgICAgICB9XG4gICAgfVxuXG4gICAgZnVuY3Rpb24gZ2V0Tm90aWZpY2F0aW9ucyhodG1sKSB7XG4gICAgICAgIGNvbnN0ICRub3RpZmljYXRpb25zQ29udGFpbmVyID0gJCgnLm5vdGlmaWNhdGlvbnMnKS5maW5kKCcuanMtbm90aWZpY2F0aW9ucy1jb250YWluZXInKTtcblxuICAgICAgICBpZiAoJG5vdGlmaWNhdGlvbnNDb250YWluZXIubGVuZ3RoKSB7XG4gICAgICAgICAgICAkbm90aWZpY2F0aW9uc0NvbnRhaW5lci5wcmVwZW5kKGh0bWxbd2luZG93LnVzZXJMYW5nXSk7XG5cbiAgICAgICAgICAgIGlmICh0eXBlb2Yga2FzcGVyc2t5LnVucmVhZENvdW50ICE9PSAndW5kZWZpbmVkJykge1xuICAgICAgICAgICAgICAgICsra2FzcGVyc2t5LnVucmVhZENvdW50O1xuICAgICAgICAgICAgfVxuICAgICAgICB9XG4gICAgfVxuXG59XG5cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9yZXNvdXJjZXMvY29tcG9uZW50cy93cy1jbGllbnQvd3MtY2xpZW50LmpzIl0sInNvdXJjZVJvb3QiOiIifQ==\n//# sourceURL=webpack-internal:///./resources/components/ws-client/ws-client.js\n");

/***/ }),

/***/ 16:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__("./resources/components/ws-client/ws-client.js");


/***/ })

/******/ });