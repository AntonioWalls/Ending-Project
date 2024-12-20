import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const getLitigious = createAsyncThunk("litigious/getLitigious",
    async (_, { rejectWithValue }) => {
        try {      
            const resp = await axios.get('http://endingapi2.somee.com/api/Litigioso/lista');
            console.log(resp.data);
            return resp.data;
        } catch (error) {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const getLitigiousUnique = createAsyncThunk("litigious/getLitigiousUnique",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.get('http://endingapi2.somee.com/api/Litigioso/Obtener/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const addLitigious = createAsyncThunk("litigious/addLitigious",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.post('http://endingapi2.somee.com/api/Litigioso/Guardar', data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const deleteLitigious = createAsyncThunk("litigious/deleteLitigious",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.delete('http://endingapi2.somee.com/api/Litigioso/Eliminar/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const editLitigious = createAsyncThunk("litigious/editLitigious",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.put(`http://endingapi2.somee.com/api/Litigioso/Editar`, data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
); 