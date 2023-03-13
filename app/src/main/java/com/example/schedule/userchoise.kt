package com.example.schedule

import android.content.Context
import android.content.Intent
import android.os.Bundle
import android.view.View
import androidx.appcompat.app.AppCompatActivity


class userchoise : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_userchoise)
    }
    public fun studentact(view: View){
        val studentInt = Intent(this, StudentActivity::class.java)
        startActivity(studentInt)
    }
    public fun teacheract(view: View){
        val prepodint = Intent(this,PrepodActivity::class.java)
        startActivity(prepodint)

    }
}