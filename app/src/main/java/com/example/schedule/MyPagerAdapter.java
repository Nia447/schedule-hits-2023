package com.example.schedule;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.recyclerview.widget.RecyclerView;
import androidx.viewpager2.adapter.FragmentStateAdapter;

import java.util.ArrayList;

public class MyPagerAdapter extends FragmentStateAdapter {

    private final ArrayList<Fragment> fragments = new ArrayList<>();
    private ArrayList<RecyclerView> recyclerViews = new ArrayList<>();
    private ArrayList<MyRecyclerViewAdapter> myRecyclerViewAdapters = new ArrayList<>();

    public MyPagerAdapter(@NonNull FragmentActivity fragmentActivity) {
        super(fragmentActivity);
    }

    public ArrayList<RecyclerView> getRecyclerViews() {
        return recyclerViews;
    }

    public ArrayList<MyRecyclerViewAdapter> getMyRecyclerViewAdapters() { return myRecyclerViewAdapters; }

    public void addRecyclerView(RecyclerView recyclerView) { recyclerViews.add(recyclerView); }

    public void addMyRecyclerViewAdapter(MyRecyclerViewAdapter myRecyclerViewAdapter) { myRecyclerViewAdapters.add(myRecyclerViewAdapter); }

    public void addFragment(Fragment fragment) {
        fragments.add(fragment);
    }

    @NonNull
    @Override
    public Fragment createFragment(int position) {
        return fragments.get(position);
    }

    @Override
    public int getItemCount() {
        return fragments.size();
    }

    public void replaceFragment(int position, Fragment fragment) {
        fragments.set(position, fragment);
        notifyDataSetChanged();
    }
}
