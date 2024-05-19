import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const getRealState = createAsyncThunk("realstates/getRealState",
    async () => {
        try
        {      
            const resp = await axios.get('http://localhost:46785/api/Inmobiliaria/lista');

            return resp.data;
        } 
        catch (error) 
        {
            return null;
        }
    }
);

