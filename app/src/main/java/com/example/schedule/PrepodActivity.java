package com.example.schedule;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class PrepodActivity extends AppCompatActivity {

    private EditText mFioEditText;
    private SharedPreferences mSharedPreferences;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_prepod);

        mFioEditText = findViewById(R.id.editTextTeacherName);

        mSharedPreferences = PreferenceManager.getDefaultSharedPreferences(this);
        String savedFIO = mSharedPreferences.getString("FIO", "");
        mFioEditText.setText(savedFIO);

        Button saveButton = findViewById(R.id.buttonSaveTeacherName);
        saveButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(mFioEditText.length() != 0 ){
                    String fio = mFioEditText.getText().toString();
                    SharedPreferences.Editor editor = mSharedPreferences.edit();
                    editor.putString("FIO", fio);
                    editor.apply();
                    Toast.makeText(PrepodActivity.this, "Saved FIO: " + fio, Toast.LENGTH_SHORT).show();
                    Intent intent = new Intent(PrepodActivity.this, MainActivity.class);
                    startActivity(intent);
                }

            }
        });
    }
}