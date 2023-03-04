package com.example.schedule;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link MondayFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class MondayFragment extends Fragment {

    public MondayFragment() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_monday, container, false);


        TextView subject1 = view.findViewById(R.id.subject1);
        subject1.setText("Математика");
        TextView time1 = view.findViewById(R.id.time1);
        time1.setText("9:00 - 10:00");

        TextView subject2 = view.findViewById(R.id.subject2);
        subject2.setText("Физика");
        TextView time2 = view.findViewById(R.id.time2);
        time2.setText("10:00 - 11:00");


        return view;
    }
}