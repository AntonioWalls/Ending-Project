import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const getReport = createAsyncThunk("report/getReport",
    async (startDate, endDate) => {
        try
        {      
            const resp = await axios.get(`http://endingapi2.somee.com/api/Report/report?startDate=${startDate}&endDate=${endDate}`);

            return resp.data;
        } 
        catch (error) 
        {
            return null;
        }
    }
);
