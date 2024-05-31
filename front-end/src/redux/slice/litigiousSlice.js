import { createSlice } from "@reduxjs/toolkit";
import { getLitigious, getLitigiousUnique } from '../actions/actionLitigious';

const initialState = {
    litigious: [],
    litigiousUnique: {},
    loading: false,
    error: null,
};

const LitigiousSlice = createSlice({
    name: "litigious",
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(getLitigious.pending, (state) => {
                state.litigious = [];
                state.loading = true;
                state.error = null;
            })
            .addCase(getLitigious.fulfilled, (state, action) => {
                state.litigious = action.payload;
                state.loading = false;
                state.error = null;
            })
            .addCase(getLitigious.rejected, (state, action) => {
                state.litigious = [];
                state.loading = false;
                state.error = action.error.message;
            })
            .addCase(getLitigiousUnique.pending, (state) => {
                state.litigiousUnique = {};
                state.loading = true;
                state.error = null;
            })
            .addCase(getLitigiousUnique.fulfilled, (state, action) => {
                state.litigiousUnique = action.payload;
                state.loading = false;
                state.error = null;
            })
            .addCase(getLitigiousUnique.rejected, (state, action) => {
                state.litigiousUnique = {};
                state.loading = false;
                state.error = action.error.message;
            });
    },
});

export const getLitigiousReducer = LitigiousSlice.reducer;
