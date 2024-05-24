import { createSlice } from "@reduxjs/toolkit";
import { getProperty, getPropertyUnique } from '../actions/actionProperty';

const initialState = {
    propertys: [],
    property: {},
    loading: false,
    error: null,
};

const propertySlice = createSlice({
    name: "getProperty",
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(getProperty.pending, (state) => {
                state.propertys = [];
                state.loading = true;
                state.error = null;
            })
            .addCase(getProperty.fulfilled, (state, action) => {
                state.propertys = action.payload;
                state.loading = false;
                state.error = null;
            })
            .addCase(getProperty.rejected, (state, action) => {
                state.propertys = [];
                state.loading = false;
                state.error = action.error.message;
            })
            .addCase(getPropertyUnique.pending, (state) => {
                state.property = {};
                state.loading = true;
                state.error = null;
            })
            .addCase(getPropertyUnique.fulfilled, (state, action) => {
                state.property = action.payload;
                state.loading = false;
                state.error = null;
            })
            .addCase(getPropertyUnique.rejected, (state, action) => {
                state.property = {};
                state.loading = false;
                state.error = action.error.message;
            });
    },
});

export const getPropertyReducer = propertySlice.reducer;