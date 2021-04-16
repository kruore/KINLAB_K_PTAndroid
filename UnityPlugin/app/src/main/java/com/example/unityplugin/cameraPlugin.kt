package com.example.unityplugin

import android.os.Bundle
import android.util.Log
import com.unity3d.player.UnityPlayerActivity

class cameraPlugin : UnityPlayerActivity(){


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        Log.d("UnityLogTest","oncreate")
    }
}