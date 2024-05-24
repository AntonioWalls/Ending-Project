import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const getRealState = createAsyncThunk("realstates/getRealState",
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

export const getRealStateUnique = createAsyncThunk("realstates/getRealStateUnique",
    async (idInmobiliaria, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.get('http://endingapi.somee.com/api/Inmobiliaria/Obtener/'+idInmobiliaria);

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
            const resp = await axios.post('http://endingapi.somee.com/api/Inmobiliaria/Guardar', data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const deleteRealState = createAsyncThunk("realstates/deleteRealState",
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

export const editRealState = createAsyncThunk("realstates/editRealState",
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
