import { createSlice } from "@reduxjs/toolkit";
import { getLitigation, getLitigationUnique } from '../actions/actionLitigation';

const initialState = {
    litigations: [],
    litigation: {},
    loading: false,
    error: null,
};

const litigationSlice = createSlice({
    name: "getLitigation",
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(getLitigation.pending, (state) => {
                state.litigations = [];
                state.loading = true;
                state.error = null;
            })
            .addCase(getLitigation.fulfilled, (state, action) => {
                state.litigations = action.payload;
                state.loading = false;
                state.error = null;
            })
            .addCase(getLitigation.rejected, (state, action) => {
                state.litigations = [];
                state.loading = false;
                state.error = action.error.message;
            })
            .addCase(getLitigationUnique.pending, (state) => {
                state.litigation = {};
                state.loading = true;
                state.error = null;
            })
            .addCase(getLitigationUnique.fulfilled, (state, action) => {
                state.litigation = action.payload;
                state.loading = false;
                state.error = null;
            })
            .addCase(getLitigationUnique.rejected, (state, action) => {
                state.litigation = {};
                state.loading = false;
                state.error = action.error.message;
            });
    },
});

export const getLitigationReducer = litigationSlice.reducer;