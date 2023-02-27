package com.example.schedule

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View

class userchoise : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_userchoise)
    }
    public fun studentact(view: View){
        val studentInt = Intent(this,Student::class.java)
        startActivity(studentInt)

    }
    public fun teacheract(view: View){
        val prepodint = Intent(this,prepod::class.java)
        startActivity(prepodint)

    }
}