package com.example.schedule;

import android.os.Bundle;
import androidx.fragment.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;


public class MondayFragment extends Fragment {

    public MondayFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_monday, container, false);
        // Добавьте свой код для фрагмента понедельника здесь
        return rootView;
    }
}