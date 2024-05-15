import React, { useEffect, useState } from 'react';
import FormReal_Estate from './FormReal_Estate';
import TableReal_Estate from './TableReal_Estate';
import { useDispatch } from 'react-redux';

function Inmobiliarias() {
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
            <FormReal_Estate showForm={showTable} id={idUserEdit}/>
        ) : (
            <TableReal_Estate showForm={showTable} idUserEdit={id => setUserEdit(id)}/>
        )
    );
}

export default Inmobiliarias;