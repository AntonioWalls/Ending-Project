import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const getAuction = createAsyncThunk("auctions/getAuction",
    async () => {
        try
        {      
            const resp = await axios.get('http://endingapi2.somee.com/api/Remate/lista');

            return resp.data;
        } 
        catch (error) 
        {
            return null;
        }
    }
);

export const getAuctionUnique = createAsyncThunk("auctions/getAuctionUnique",
    async (idRemate, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.get('http://endingapi2.somee.com/api/Remate/Obtener/'+idRemate);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const addAuction = createAsyncThunk("Auctions/addAuction",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.post('http://endingapi2.somee.com/api/Remate/Guardar', data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const deleteAuctions = createAsyncThunk("auctions/deleteAuctions",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.delete('http://endingapi2.somee.com/api/Remate/Eliminar/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const editAuction = createAsyncThunk("auctions/editAuctions",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.put(`http://endingapi2.somee.com/api/Remate/Editar`, data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);
