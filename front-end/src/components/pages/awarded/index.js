import React, { useEffect, useState } from 'react';
import FormAwarded from './FormAwarded';
import TableAwarded from './TableAwarded';
import { useDispatch } from 'react-redux';

function Usuarios() {
    const dispatch = useDispatch();
    const [showForm, setShowForm] = useState(false);
    const [idUserEdit, setUserEdit] = useState(0);

    const showTable = () => {
        setShowForm(prevShowForm => !prevShowForm); // Utilizando el estado anterior
        if(showForm){
            setUserEdit(idUserEdit);
        }
    };

    useEffect(() => {
        
    }, [dispatch, idUserEdit]);

    return (
        showForm ? (
            <FormAwarded showForm={showTable} id={idUserEdit}/>
        ) : (
            <TableAwarded showForm={showTable} idUserEdit={id => setUserEdit(id)}/>
        )
    );
}

export default Usuarios;