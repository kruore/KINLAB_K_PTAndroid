package com.example.kinlab_k_pt_android;

import android.content.ContentProvider;
import android.content.Context;
import android.widget.Toast;

public class CameraActivity{

    private static  CameraActivity m_instance;

    public static CameraActivity instance(){
        if(m_instance == null)
        {
            m_instance = new CameraActivity();
        }
        return m_instance;
    }

    private Context context;
    private void setContext(Context con)
    {
        this.context = context;
    }

    private  void ShowToast(String toastSt)
    {
        Toast.makeText(this.context,toastSt, Toast.LENGTH_LONG).show();
    }

}
