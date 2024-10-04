function show(id,pad,right)
	{
		var men="menu"+id;
		var men2="mn1_"+id+"b";
		var men3="mn1_"+id+"a";
		document.getElementById("menu0").style.display='none';	
		document.getElementById(men).style.display='block';	
		
		document.getElementById(men2).style.display='block';
		document.getElementById(men3).style.display='none';
		if(pad)
		{document.getElementById(men).style.textAlign='right';	}
		if(right)
		{
			document.getElementById('rss_search').style.display='none';	
			document.getElementById(men).style.width='900px'
		}
	}

	function hidden(id)
	{
		var men="menu"+id;
		var men3="mn1_"+id+"b";
		var men2="mn1_"+id+"a";
		document.getElementById(men).style.display='none';
		document.getElementById("menu0").style.display='block';	
		document.getElementById("rss_search").style.display='block';	
		document.getElementById(men3).style.display='none';
		document.getElementById(men2).style.display='block';
		
	}
	
	function show2(id,pad)
	{
		var men="menu2_"+id;
		var men2="mn2_"+id+"b";
		var men3="mn2_"+id+"a";
		document.getElementById("menu2_0").style.display='none';	
		document.getElementById(men).style.display='block';	
		document.getElementById(men2).style.display='block';
		document.getElementById(men3).style.display='none';
		if(pad)
		{document.getElementById(men).style.padding='2px 0px 0px '+pad+'px';	}
	}

	function hidden2(id)
	{
		var men="menu2_"+id;
		var men3="mn2_"+id+"b";
		var men2="mn2_"+id+"a";
		document.getElementById(men).style.display='none';
		document.getElementById("menu2_0").style.display='block';	
		document.getElementById(men3).style.display='none';
		document.getElementById(men2).style.display='block';
		
	}