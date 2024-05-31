import { createSlice } from "@reduxjs/toolkit";
import { getReport } from '../actions/actionReport';

const initialState = {
    report: [],
    loading: false,
    error: null,
};

const reportSlice = createSlice({
    name: "getReport",
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(getReport.pending, (state) => {
                state.report = [];
                state.loading = true;
                state.error = null;
            })
            .addCase(getReport.fulfilled, (state, action) => {
                state.report = action.payload;
                state.loading = false;
                state.error = null;
            })
            .addCase(getReport.rejected, (state, action) => {
                state.report = [];
                state.loading = false;
                state.error = action.error.message;
            })
        },
    });

export const getReportReducer = reportSlice.reducer;