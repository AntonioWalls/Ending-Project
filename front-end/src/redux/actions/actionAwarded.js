import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const getAwarded = createAsyncThunk("awarded/getAwarded",
    async () => {
        try
        {      
            const resp = await axios.get('http://endingapi.somee.com/api/Inmobiliaria/lista');

            return resp.data;
        } 
        catch (error) 
        {
            return null;
        }
    }
);

export const getAwardedUnique = createAsyncThunk("awarded/getAwardedUnique",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.get('http://endingapi.somee.com/api/Inmobiliaria/Obtener/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const addAwardedState = createAsyncThunk("awarded/addAwarded",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.post('http://endingapi.somee.com/api/Inmobiliaria/Guardar', data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const deleteAwarded = createAsyncThunk("awarded/deleteAwarded",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.delete('http://endingapi.somee.com/api/Inmobiliaria/Eliminar/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const editAwarded = createAsyncThunk("awarded/editAwarded",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.put('http://187.189.158.186:7777/Usuario/'+data.id, data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);
