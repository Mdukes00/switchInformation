; (function (window) {

    function UISearch(el, options) {
        this.el = el;
        this.inputEl = el.querySelector('form > input.sb-search-input');
        this._initEvents();
    }

    UISearch.prototype = {
        _initEvents: function () {
            var self = this,
				initSearchFn = function (ev) {
				    if (!classie.has(self.el, 'sb-search-open')) { // open it
				        ev.preventDefault();
				        self.open();
				    }
				    else if (classie.has(self.el, 'sb-search-open') && /^\s*$/.test(self.inputEl.value)) { // close it
				        self.close();
				    }
				}

            this.el.addEventListener('click', initSearchFn);
            this.inputEl.addEventListener('click', function (ev) { ev.stopPropagation(); });
        },
        open: function () {
            classie.add(this.el, 'sb-search-open');
        },
        close: function () {
            classie.remove(this.el, 'sb-search-open');
        }
    }

    // add to global namespace
    window.UISearch = UISearch;

})(window);
