Element.addMethods({
	getRealHeight: function(element) {
		element = $(element);
		var realHeight = jQuery(element).height();
		return realHeight;
	},
	trimToLine: function(element, max) {
		element = $(element);
		// element height must be auto
		element.setStyle({height:'auto'});
		max = (typeof max == 'number' && max > 1) ? max : 1;
		// get the line-height
		var lineHeight = element.getStyle('line-height');
		if (lineHeight === 'normal' || !lineHeight.match(/px$/)) {
			// line-height must be calculated
			var temp = element.innerHTML;
			element.update('X');
			lineHeight = parseFloat(element.getRealHeight());
			element.update(temp);
			temp = null;
			if (typeof console != 'undefined') {
				console.log('calculating line height: '+lineHeight);
			} else {
				// alert('calculating line height: '+lineHeight);
			}
		} else {
			lineHeight = parseFloat(lineHeight);
		}
		var height = element.getRealHeight();
		var lines = Math.round(height/lineHeight);
		if (lines > max) {
			// save full length string in title attribute
			element.setAttribute('title', jQuery.trim(element.innerHTML));
			var length = element.innerHTML.length;
			var avgChars = Math.ceil(length/lines);
			// trim to two lines of characters
			if (length > (avgChars*2*max)) {
				element.update(element.innerHTML.substring(0,(avgChars*2*max)));
			}
			// trim one character at a time until the height is max lines tall
			var maxHeight = Math.round(lineHeight*max);
			while ((element.getRealHeight() > maxHeight) && (element.innerHTML.length > (avgChars*0.8))) {
				element.update(element.innerHTML.substring(0,element.innerHTML.length-1));
			}
			// make room for the hellip
			var result = element.innerHTML.substring(0,element.innerHTML.length-3);
			// remove any non-word characters from the end
			while (result.match(/\W$/) && (result.length > 1)) {
				result = result.substring(0,result.length-1);
			}
			// add the hellip
			element.update(result+'&hellip;');
		}
	}
});
