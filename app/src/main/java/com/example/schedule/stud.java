package com.example.schedule;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.content.Context;
import android.content.SharedPreferences;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class stud extends AppCompatActivity {
    private EditText mEditText;
    private Button mButton;
    private SharedPreferences mSharedPreferences;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_stud);

        mEditText = findViewById(R.id.input);
        mButton = findViewById(R.id.ok_button);
        mSharedPreferences = getSharedPreferences("MyPrefs", Context.MODE_PRIVATE);

        mButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String groupNumber = mEditText.getText().toString();
                SharedPreferences.Editor editor = mSharedPreferences.edit();
                editor.putString("GroupNumber", groupNumber);
                editor.apply();
                System.out.println(mSharedPreferences);
            }
        });
    }
}