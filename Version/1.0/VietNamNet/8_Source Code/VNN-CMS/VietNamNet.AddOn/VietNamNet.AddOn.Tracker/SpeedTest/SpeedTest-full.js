srvSpeedTest_url='/tracking/t.srv?'
        +'sn=speedtest&dm=demo.vietnamnet.vn&us=me&vs=1'
        +'&getTime=[GETTIME]&startTime=[STARTTIME]&endTime=[ENDTIME]'
        +'&KbPerSec=[BANDWIDTH]&fileSize=[FILESIZE]';
srvPingTest_url='/ajax/ping/g.html' ;
srvPingTest_posturl='/tracking/t.srv?'+
                'sn=ping&dm=demo.vietnamnet.vn&us=me&vs=1'+
                '&startTime=[STARTTIME]&endTime=[ENDTIME]'+
                '&pingCommand=[pingCommand]&ipAddress=[ipAddress]&byteSize=[byteSize]'+
                '&sentPings=[sentPings]&receivedPings=[receivedPings]&lostPings=[lostPings]'+
                '&minPingResponse=[minPingResponse]&maxPingResponse=[maxPingResponse]&averageTimeResponse=[averageTimeResponse]'; 
                
srvTracertTest_url='/ajax/tracert/g.html' ;
srvTracertTest_posturl='/tracking/t.srv?'+
                'sn=tracert&dm=demo.vietnamnet.vn&us=me&vs=1'+
                '&startTime=[STARTTIME]&endTime=[ENDTIME]'+
                '&traceResponse=[traceResponse]'; 
                

srvFileTest40K_url='/SpeedTest/file30K.txt';srvFileTest30K_url='/SpeedTest/file40K.txt';srvFileTest60K_url='/SpeedTest/file60K.txt';
fSize30K=30727;fSize40K=41009;fSize60K=61444;
        
tempSpeedTest=  '<div class="container"><iframe src="" class="post" style="display:none;"></iframe></div> ';

 var divId='dShow';
 
var containerEl = $('#'+divId + ' .loading .frame');
    
    var startTestTime;
    var endTestTime;
    var imgFilename = "/SpeedTest/imgs/bg_form.gif";
    var imgSize = 45917;
    var loadTimeInSec;
    var KbPerSec;
    var containerEl;

var fSizeTotal=0;
var loadTimeTotal=0;

function runProcess(){
    $('#'+divId + ' .loading .frame').html(tempSpeedTest);
    startTestTime=(new Date()).getTime();     
    $('#dShow [name="TestOption"]').each(function(){
        if (this.checked == true ){
            if (this.value==0){
                $('#'+divId + ' #imgLoad').attr('class','imgloading'); 
                fSizeTotal=0;loadTimeTotal=0;
                setTimeout( 'setSetFileTest("30K")' , 1000);
                
            }else if (this.value==1){
                $('#'+divId + ' #imgLoad').attr('class','imgloading'); 
                setTimeout( 'pingTest()' , 1000); 
            }else if (this.value==2){
                $('#'+divId + ' #imgLoad').attr('class','imgloading'); 
                setTimeout( 'tracertTest()' , 1000);   
            }
        }
    });
};

function pingTest()
{
    VietNamNet.Framework.JS.AjaxManager.add({
        url: srvPingTest_url + "?ranid="+ Math.random(),
        success: function(output){ 
            var obj = VietNamNet.Framework.JS.JSON.decode(output); 
            
            $('#'+divId + " .result .mess").html(obj.PingCommand.replace(/\r\n/ig,"<br />")); 
            endTestTime=(new Date()).getTime();
            //Gui du lieu len Server, ghi cookie
                     $('#'+divId + ' .post').attr({ 
                                  src: srvPingTest_posturl.replace("[pingCommand]",obj.PingCommand).replace("[ipAddress]",obj.IpAddress).replace("[byteSize]",obj.ByteSize)
                                                        .replace("[sentPings]",obj.SentPings).replace("[receivedPings]",obj.ReceivedPings).replace("[lostPings]",obj.LostPings)
                                                        .replace("[minPingResponse]",obj.MinPingResponse).replace("[maxPingResponse]",obj.maxPingResponse).replace("[averageTimeResponse]",obj.AverageTimeResponse)
                                                        .replace("[STARTTIME]",startTestTime).replace("[ENDTIME]",endTestTime),
                                  title: "post" 
                        });           
            
            
            $('#'+divId + ' #imgLoad').attr('class','invisible'); 
        }
    })
};

function tracertTest(){
     VietNamNet.Framework.JS.AjaxManager.add({
        url: srvTracertTest_url + "?ranid="+ Math.random(),
        success: function(output){ 
            //var obj = VietNamNet.Framework.JS.JSON.decode(output); 
            
            $('#'+divId + " .result .mess").html(output.replace(/\r\n/ig,"<br />")); 
            endTestTime=(new Date()).getTime();
            //Gui du lieu len Server, ghi cookie
                     $('#'+divId + ' .post').attr({ 
                                  src: srvTracertTest_posturl.replace("[traceResponse]",output)
                                                            .replace("[STARTTIME]",startTestTime).replace("[ENDTIME]",endTestTime),
                                  title: "post" 
                        });           
            
            
            $('#'+divId + ' #imgLoad').attr('class','invisible'); 
        }
    }) 
};

function setSetFileTest(fileSize){
    var srvFileTest_url;var fSize;
    
    if (fileSize=='30K'){
        srvFileTest_url=srvFileTest30K_url;
        fSize=fSize30K;   
    }else if (fileSize=='40K'){
        srvFileTest_url=srvFileTest40K_url;
        fSize=fSize40K;
    }else if (fileSize=='60K'){
        srvFileTest_url=srvFileTest60K_url;
        fSize=fSize60K;
    }else {return;}
    
    fSizeTotal+=fSize;
    
    //$('#'+divId).html(tempSpeedTest);
   
    var d = new Date();
    var startTime=d.getTime();
    var endTime;
    
    VietNamNet.Framework.JS.AjaxManager.add({
        url: srvFileTest_url + "?ranid="+ Math.random(),
        success: function(output){
            
             
            d = new Date(); endTime=d.getTime();
                        endTestTime=endTime;
            loadTimeTotal+=(endTime-startTime) ;
            var KbPerSec = ((fSizeTotal * 8) / (loadTimeTotal / 1000)) /1024;

             var mess=  "Dung lượng file: " + (fSizeTotal / 1024).toFixed(0) + " Kb" + "<br/>" +
                        "Thời gian tải file: " + (loadTimeTotal / 1000) + " giây" + "<br/>" +
                        "Tốc độ tải: " + (KbPerSec / 1024).toFixed(3) + " Mbps";
            $('#'+divId + " .result .mess").html(mess);
             
             
             
             if (fileSize=='60K'){ 
                    $('#'+divId + ' #imgLoad').attr('class','invisible'); 
                    
                    //Gui du lieu len Server, ghi cookie
                     $('#'+divId + ' .post').attr({ 
                                  src: srvSpeedTest_url.replace("[GETTIME]",loadTimeTotal).replace("[STARTTIME]",startTestTime).replace("[ENDTIME]",endTestTime)
                                                        .replace("[BANDWIDTH]",KbPerSec).replace("[FILESIZE]",fSizeTotal),
                                  title: "post" 
                        });
             } else if (fileSize=='30K'){ // Load file 40K sau 1s
                setTimeout( 'setSetFileTest("40K")' , 1000);
             }else if (fileSize=='40K'){ // Load file 60K sau 1s
                setTimeout( 'setSetFileTest("60K")' , 1000);
             }
             
             
        }
    });
};
 
  
$(function(){ 
    //setTimeout( 'setSetFileTest("30K")' , 1000); // sau 5s
    //setTimeout( 'setSetFileTest("40K")' , 1000); // sau 10s
    //setTimeout( 'setSetFileTest("60K")' , 1000); // sau 15s
});

