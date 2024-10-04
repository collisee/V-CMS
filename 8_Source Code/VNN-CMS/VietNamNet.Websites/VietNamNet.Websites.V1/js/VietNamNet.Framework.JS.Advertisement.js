VietNamNet.Framework.JS.Advertisement = {
    layout : {},
    init: function(obj){
        var layout = this.layout = obj;
        
        if (layout.zones && layout.zones.length && layout.zones.length > 0){
            for (var i = 0; i < layout.zones.length; i++){
                VietNamNet.Framework.JS.Advertisement.bindZone(layout.zones[i]);
            }
        }
    },
    bindZone: function(zone){
        $('#' + zone.holderId).each(function(){
            //set name
            $(this).attr('zoneId', zone.id).attr('zoneName', zone.name);
            
            //bind block
            if (zone.blocks && zone.blocks.length && zone.blocks.length > 0){
                //clear old data
                $(this).empty();
                
                //get order
                var rB = [];
                for (var i = 0; i < zone.blocks.length; i++) rB[i] = i; // order
                
                if (!zone.mode){ //random
                    rB = randomOrder(rB);
                }
                //bind data
                for (var i = 0; i < zone.blocks.length; i++){
                    VietNamNet.Framework.JS.Advertisement.bindBlock(this, zone.blocks[rB[i]], zone.direction, (i == zone.blocks.length - 1));
                }
            }
            
            //bind clear 4 float
            if (zone.direction){
                var c = '<br class="clear" />';
                $(c).appendTo($(this));
            }
        });
    },
    bindBlock: function(zone, block, direction, last){
        var b = '<div></div>';
        block.holder = $(b).css({
                width: block.width, 
                height: block.height,
                float: (direction ? 'left' : ''),
                paddingRight: (direction && !last ? 2 : 0),
                paddingBottom: (!direction && !last ? 10 : 0)
            }).attr('blockId', block.id).attr('blockName', block.name).appendTo($(zone));
        
        //bind data
        if (block.items && block.items.length && block.items.length > 0){
            if (block.items.length == 1) { // only 1 item
                VietNamNet.Framework.JS.Advertisement.bindItem(block, block.items[0]);
            }else{ // more than 1 item
                //get order
                var rI = [];
                for(var i = 0; i< block.items.length; i++)rI[i] = i; //order
                
                if (!block.mode){ //random
                    rI = randomOrder(rI);
                }
                
                //bind Item
                VietNamNet.Framework.JS.Advertisement.bindItem(block, block.items[rI[0]]);
                var index = 1;
                window.setInterval(function(){
                    VietNamNet.Framework.JS.Advertisement.bindItem(block, block.items[rI[index]]);
                    index++;
                    if (index >= rI.length) index = 0;
                }, block.timeDelay);
            }
        }else{ //hidden
            $(block.holder).hide();
        }
    },
    bindItem: function(block, item){
        //clear data
        $(block.holder).empty();
        
        //bind item
        switch (item.typeAlias){
            case 'flash':
                var flash = '<div> \r\n' + 
                            '<embed width="' + block.width + '" height="' + block.height + '" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer"  \r\n'+
                            '    type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player"  \r\n'+
                            '    wmode="transparent" quality="high" src="' + item.fileLink1 + '" />  \r\n'+
                            ' </div>';
                $(block.holder).append($(flash).attr('itemId', item.id).attr('itemName', item.name));
                break;
            case 'image':
                var image = '<div> \r\n' + 
                            ' <a href="' + item.link+ '" onclick="javascript: VietNamNet.Framework.JS.Advertisement.tracking(\'' + item.link + '\');" target="_blank"> ' +
                            '<img width="' + block.width + '" height="' + block.height + '" alt="Qu&#7843;ng c&#225;o" title="Qu&#7843;ng c&#225;o" src="' + item.fileLink1 + '" />'+
                            ' </a> \r\n' +
                            ' </div>';
                $(block.holder).append($(image).attr('itemId', item.id).attr('itemName', item.name));
                break;
            case 'add-code':
                //include file first, call code after
                if (!item.exMode){
                    if (item.fileJS){ //files existed
                        var files = item.fileJS.split(';');
                        if (files && files.length && files.length > 0){
                            var loadFileJS = function(fI){
                                vnnLoadFile(files[fI], 'js', $(block.holder).get(0), function(){
                                    if (fI+1 >= files.length){ //call function
                                        eval(item.codeJS);
                                    }else{ //load next
                                        loadFileJS(fI+1);
                                    }
                                });
                            };
                            loadFileJS(0);
                        }
                    }else{ //files not existed
                        eval(item.codeJS);
                    }
                }else{ //call code first, include file after
                    eval(item.codeJS);
                    if (item.fileJS){ //files existed
                        var files = item.fileJS.split(';');
                        if (files && files.length && files.length > 0){
                            for (var i = 0; i < files.length; i++){
                                vnnLoadFile(files[i], 'js', $(block.holder).get(0));
                            }
                        }
                    }
                }
                //hide block
                $(block.holder).hide();
                break;
            case 'expanding':
                var expanding = '<div> \r\n' + 
                            '<embed width="' + block.width + '" height="' + block.height + '" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer"  \r\n'+
                            '    type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player"  \r\n'+
                            '    wmode="transparent" quality="high" src="' + item.fileLink1 + '" />  \r\n'+
                            ' </div>';
                $(block.holder).append($(expanding).attr('itemId', item.id).attr('itemName', item.name));
                break;
            case 'iframe':
                if (item.fileJS){ //check src
                    var iframe = '<iframe name="iframe_name" width="' + block.width + '" height="' + block.height + '" frameborder="0" scrolling="no" src="' + item.fileJS + '">' +
                                 'Your browser does not support inline frames or is currently configured not to display ' +
                                 'inline frames. </iframe>';
                    $(block.holder).append($(iframe).attr('itemId', item.id).attr('itemName', item.name));
                }else{ //hide block
                    $(block.holder).hide();
                }
                break;
            default:
                break;
        }
    },
    tracking: function(link){
        try{
            if (pageTracker && pageTracker._trackPageview) {
                pageTracker._trackPageview('/adv/' + item.link.replace('http://',''));
            }
        }catch(ex){
        }
    }
};