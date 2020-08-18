mergeInto(LibraryManager.library, 
{
	// Useful references
	// https://webmidi-examples.glitch.me/
	// https://www.w3.org/TR/webmidi/
	MIDI_Init : function()
    {
		// This can happen if multiple windows are open
		// that are trying to access MIDI.
		if(navigator.requestMIDIAccess == null)
			return false;

		//https://stackoverflow.com/questions/5786851/define-global-variable-in-a-javascript-function/5786899
		if(window.pxpreMIDI == null)
		{
			window.pxpreMIDI			= {};
			window.pxpreMIDI["req"]		= "waiting";
			window.pxpreMIDI["midi"]	= null;
			window.pxpreMIDI["reqErr"]	= "";
			window.pxpreMIDI["msgs"]	= [];
			
			navigator.requestMIDIAccess().
				then(
					function(midi)
					{
						window.pxpreMIDI.req = "success";
						window.pxpreMIDI.midi = midi;
					},
					function(err)
					{
						window.pxpreMIDI.req = "error";
						window.pxpreMIDI.reqErr = err;
					});
			
			return true;
		}
		return false;
	},
	
	MIDI_Check : function()
	{
		var pxpm = window.pxpreMIDI;
		if(pxpm == null)
			return false;
			
		if(pxpm.req == null || pxpm.req == "waiting")
			return false;
			
		if(pxpm.midi == null)
			return false;
			
		return true;
	},
	
	MIDI_QueryOutputDevices : function()
	{
		var ret = [];
		
		var pxpm = window.pxpreMIDI;
		if(pxpm != null && pxpm.midi != null)
		{
			// We got to do some syntax gymnastics here because
			// emscripten can't handle newer syntax
			var it = pxpm.midi.outputs.values();
			while(true)
			{
				var v = it.next();
				if(v.done == true)
					break;

				midiOut = v.value;
				var o = {};
				o.connection 	= midiOut.connection;
				o.id 			= midiOut.id;
				o.manufacturer 	= midiOut.manufacturer;
				o.name 			= midiOut.name;
				o.onstatechg 	= midiOut.onstatechange ? "filled" : "empty";
				o.state 		= midiOut.state;
				o.type 			= midiOut.type;
				o.version 		= midiOut.version;

				ret.push(o);
			}	
		}

		var retstr = JSON.stringify(ret);
		var retlen = lengthBytesUTF8(retstr) + 1;
		var buffer = _malloc(retlen);
		stringToUTF8(retstr, buffer, retlen);
		return  buffer;
	},
	
	MIDI_QueryInputDevices : function()
	{
		var ret = [];
		
		var pxpm = window.pxpreMIDI;
		if(pxpm != null && pxpm.midi != null)
		{
			// We got to do some syntax gymnastics here because
			// emscripten can't handle newer syntax
			var it = pxpm.midi.inputs.values();
			while(true)
			{
				var v = it.next();
				if(v.done == true)
					break;

				midiIn = v.value;
				var o = {};
				o.connection 	= midiIn.connection;
				o.id 			= midiIn.id;
				o.manufacturer	= midiIn.manufacturer;
				o.name			= midiIn.name;
				o.onmidimsg		= midiIn.onmidimessage ? "filled" : "empty";
				o.onstatechg	= midiIn.onstatechange ? "filled" : "empty";
				o.state			= midiIn.state;
				o.type			= midiIn.type;
				o.version		= midiIn.version;
		
				ret.push(o);
			}	
		}
		
		var retstr = JSON.stringify(ret);
		var retlen = lengthBytesUTF8(retstr) + 1;
		var buffer = _malloc(retlen);
		stringToUTF8(retstr, buffer, retlen);
		return  buffer;
	},

	MIDI_EnableInputDevice : function(name, id)
	{
		var pxpm = window.pxpreMIDI;
		if(pxpm == null || pxpm.midi == null)
			return false;

		var strName = Pointer_stringify(name);
		var strId = Pointer_stringify(id);

		var it = pxpm.midi.inputs.values();
		while(true)
		{
			var v = it.next();
			if(v.done == true)
				break;

			if(v.value.name == strName && v.value.id == strId)
			{
				v.value.onstatechange = 
					function(x)
					{
						var sc		= {};
						sc["msg"]	= "statechange";
						sc["id"]	= x.srcElement.id;
						sc["name"]	= x.srcElement.name;
						sc["state"] = x.srcElement.state;

						pxpm.msgs.push(sc);
					};

				v.value.onmidimessage = 
					function(x)
					{
						window.temp = x;
						var mm		= {};
						mm["msg"]	= "msg";
						mm["id"]	= x.srcElement.id;
						mm["name"]	= x.srcElement.name;
						mm["data"]	= Array.from(x.data);

						pxpm.msgs.push(mm);
					};
				return true;
			}
		}
		return false;
	},

	MIDI_DisableInputDevice : function(name, id)
	{
		var pxpm = window.pxpreMIDI;
		if(pxpm == null || pxpm.midi == null)
			return false;

		var strName = Pointer_stringify(name);
		var strId = Pointer_stringify(id);

		var it = pxpm.midi.inputs.values();

		while(true)
		{
			var v = it.next();
			if(v.done == true)
				break;

			if(v.value.name == strName && v.value.id == strId)
			{
				v.value.onstatechange = null;
				v.value.onmidimessage = null;
				return true;
			}
		}
		return false;
	},

	MIDI_IsInputConnected : function(name, id)
	{
		var pxpm = window.pxpreMIDI;
		if(pxpm == null || pxpm.midi == null)
			return false;

		var strName = Pointer_stringify(name);
		var strId = Pointer_stringify(id);

		var it = pxpm.midi.inputs.values();
		while(true)
		{
			var v = it.next();
			if(v.value.name != strName || v.value.id != strId)
				continue;
			
			return (v.value.connection == "open");
		}
		return false;
	},

	MIDI_EnableOutputDevice : function(name, id)
	{
		var pxpm = window.pxpreMIDI;
		if(pxpm == null || pxpm.midi == null)
			return false;

		var strName = Pointer_stringify(name);
		var strId = Pointer_stringify(id);

		var it = pxpm.midi.outputs.values();
		while(true)
		{
			var v = it.next();
			if(v.done == true)
				break;

			if(v.value.name == strName && v.value.id == strId)
			{
				v.value.onstatechange = 
					function(x)
					{
						var sc		= {};
						sc["msg"]	= "statechange";
						sc["id"]	= x.srcElement.id;
						sc["name"]	= x.srcElement.name;
						sc["state"] = x.srcElement.state;

						pxpm.msgs.push(sc);
					};
				return true;
			}
		}
		return false;
	},

	MIDI_DisableOutputDevice : function(name, id)
	{
		var pxpm = window.pxpreMIDI;
		if(pxpm == null || pxpm.midi == null)
			return false;

		var strName = Pointer_stringify(name);
		var strId = Pointer_stringify(id);

		var it = pxpm.midi.outputs.values();
		while(true)
		{
			var v = it.next();
			if(v.done == true)
				break;

			if(v.value.name == strName && v.value.id == strId)
			{
				v.value.onstatechange = null;
				return true;
			}
		}
		return false;
	},

	MIDI_IsOutputConnected : function(name, id)
	{
		var pxpm = window.pxpreMIDI;
		if(pxpm == null || pxpm.midi == null)
			return false;

		var strName = Pointer_stringify(name);
		var strId = Pointer_stringify(id);

		var it = pxpm.midi.outputs.values();
		while(true)
		{
			var v = it.next();
			if(v.value.name != strName || v.value.id != strId)
				continue;
			
			return (v.value.connection == "open");
		}
		return false;
	},

	MIDI_InputMessageCount : function()
	{
		var pxpm = window.pxpreMIDI;
		if(pxpm == null || pxpm.midi == null)
			return 0;

		return  pxpm.msgs.length;
	},

	MIDI_FlushMessagesJSON : function()
	{
		var pxpm = window.pxpreMIDI;
		if(pxpm == null || pxpm.midi == null)
			return 0;

		var msgs = pxpm.msgs;
		window.pxpreMIDI.msgs = [];
		var retstr = JSON.stringify(msgs);

		var retlen = lengthBytesUTF8(retstr) + 1;
		var buffer = _malloc(retlen);
		stringToUTF8(retstr, buffer, retlen);
		return  buffer;
	},

	MIDI_SendOutputMsg : function(name, id, jsonPayload)
	{
		var pxpm = window.pxpreMIDI;
		if(pxpm == null || pxpm.midi == null)
			return false;

		var strName = Pointer_stringify(name);
		var strId = Pointer_stringify(id);

		var strPayload = Pointer_stringify(jsonPayload);
		var objPL = JSON.parse(strPayload);
		window.delme = objPL;

		var it = pxpm.midi.outputs.values();
		while(true)
		{
			var v = it.next();
			if(v.done == true)
				break;

			if(v.value.name == strName && v.value.id == strId)
			{
				v.value.send(objPL);
				return true;
			}
		}
		return false;
	},
});