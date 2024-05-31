import React, { useEffect, useState } from 'react';
import FormReport from './FormReport'; // Asegúrate de que el import sea correcto
import { useDispatch } from 'react-redux';
import TableReport from './TableReport';

function Inmobiliarias() {
  const dispatch = useDispatch();
  const [showForm, setShowForm] = useState(false);
  const [idUserEdit, setUserEdit] = useState(0);
  const [initialDate, setInitialtDate] = useState(new Date()); // Estado para la fecha seleccionada
  const [ultimateDate, setUltimateDate] = useState(new Date()); // Estado para la fecha seleccionada

  const showTable = () => {
    setShowForm(prevShowForm => !prevShowForm); // Utilizando el estado anterior
  };

  useEffect(() => {
    // Aquí puedes manejar efectos secundarios, si es necesario
  }, [dispatch, idUserEdit, initialDate, ultimateDate]);

  return (
    showForm ? (
      <TableReport 
      showForm={showTable} 
      idInmobiliaria={idUserEdit}
      startDate={initialDate.toISOString().split('T')[0]}
      endDate={ultimateDate.toISOString().split('T')[0]}
      />
    ) : (
      <FormReport
        showForm={showTable}
        idUserEdit={id => setUserEdit(id)}
        initialDate={date => setInitialtDate(date)}
        ultimateDate={date => setUltimateDate(date)}
      />
    )
  );
}

export default Inmobiliarias;