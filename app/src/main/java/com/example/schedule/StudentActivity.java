package com.example.schedule;

import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.Group;

import android.content.Intent;
import android.os.Bundle;
import android.content.SharedPreferences;
import android.preference.PreferenceManager;
import android.provider.Settings;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.view.inputmethod.EditorInfo;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

import com.example.schedule.model.dto.GroupDto;
import com.example.schedule.model.dto.GroupListDto;
import com.example.schedule.model.dto.TeacherDto;
import com.example.schedule.model.dto.TeachersListDto;
import com.example.schedule.scheduleapi.ScheduleService;
import com.example.schedule.scheduleapi.SelectionService;
import com.squareup.moshi.JsonAdapter;
import com.squareup.moshi.Moshi;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;

import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.Converter;
import retrofit2.converter.jackson.JacksonConverterFactory;

public class StudentActivity extends AppCompatActivity {
    private EditText groupNumberEditText;
    private Button mButton;
    public SharedPreferences mSharedPreferences;
    private ListView optionsListView;
    private ArrayAdapter<String> optionsAdapter;
    private SelectionService apiService;
    private JsonAdapter<GroupListDto> jsonAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_stud);

        GlobalApplication application = (GlobalApplication) getApplication();
        Moshi moshi = application.getMoshi();
        jsonAdapter = moshi.adapter(GroupListDto.class);
        apiService = application.getSelectionService();

        groupNumberEditText = findViewById(R.id.groupNumberEditText);
        mButton = findViewById(R.id.ok_button);

        groupNumberEditText = findViewById(R.id.groupNumberEditText);
        optionsListView = findViewById(R.id.optionsListView);
        optionsAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1);
        optionsListView.setAdapter(optionsAdapter);

        mSharedPreferences = PreferenceManager.getDefaultSharedPreferences(this);
        String _groupNumber = mSharedPreferences.getString("GroupNumber", "");
        Boolean savedIsStudent = mSharedPreferences.getBoolean("IsStudent", true);
        groupNumberEditText.setText(_groupNumber);
        optionsListView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                String selectedOption = optionsAdapter.getItem(position);
                groupNumberEditText.setText(selectedOption);
            }
        });

        if (apiService == null) {
            optionsAdapter.add("null");
        }

        groupNumberEditText.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                String groupNumber = groupNumberEditText.getText().toString();
                loadOptionsFromServer(groupNumber);
            }

            @Override
            public void afterTextChanged(Editable s) {
            }
        });

        mButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (groupNumberEditText.length() != 0) {
                    String groupNumber = groupNumberEditText.getText().toString();
                    SharedPreferences.Editor editor = mSharedPreferences.edit();
                    editor.putString("GroupNumber", groupNumber);
                    editor.putBoolean("IsStudent", true);
                    editor.putString("Id", ""); // TODO: From Select Get Id
                    editor.apply();

                    Intent intent = new Intent(StudentActivity.this, MainActivity.class);
                    startActivity(intent);
                    finish();
                }
            }
        });


    }

    private void loadOptionsFromServer(String groupNumber) {
        Call<GroupListDto> optionsCall = apiService.getGroupListDto(groupNumber);
        optionsCall.enqueue(new Callback<GroupListDto>() {
            @Override
            public void onResponse(Call<GroupListDto> call, Response<GroupListDto> response) {
                if (response.isSuccessful()) {
                    GroupListDto options = response.body();

                    List<String> selectList = new ArrayList<>();

                    for (GroupDto group : options.groups){
                        selectList.add(group.number);
                    }

                    optionsAdapter.clear();
                    optionsAdapter.addAll(selectList);
                } else {
                    Toast.makeText(StudentActivity.this, "Не удалось получить список вариантов", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<GroupListDto> call, Throwable t) {
                Toast.makeText(StudentActivity.this, "Ошибка: " + t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }
}