package com.example.unitylove;

import android.content.Context;
import android.widget.Toast;


public class Uplugin {

    private static Uplugin m_instance;

    private Context context;

    public static Uplugin instance(){
        if(m_instance==null){
            m_instance = new Uplugin();
        }
        return m_instance;
    }

    private  void setContext(Context ct){
        context = ct;
    }

    private  void ShowToast(String msg,int i){
        if(i==0) {
            Toast.makeText(context,msg,Toast.LENGTH_SHORT).show();
        }else {
            Toast.makeText(context,msg,Toast.LENGTH_LONG).show();
        }
    }
}
