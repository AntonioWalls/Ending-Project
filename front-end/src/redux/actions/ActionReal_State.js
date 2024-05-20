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

export const getRealStateUnique = createAsyncThunk("realstates/getRealStateUnique",
    async (idInmobiliaria, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.get('http://187.189.158.186:7777/Usuario/'+idInmobiliaria);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const addRealState = createAsyncThunk("realstates/addRealState",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.post('', data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

