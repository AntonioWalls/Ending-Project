import 'bootstrap/dist/css/bootstrap.min.css';
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Button, Col, Row } from 'react-bootstrap';
import { AgGridReact } from 'ag-grid-react';
import { getReport } from '../../../redux/actions/actionReport';
import Swal from 'sweetalert2';

export default function TableReport({ showForm, idUserEdit, startDate, endDate }) {
  const dispatch = useDispatch();
  const { report } = useSelector((state) => state.getReport);

  useEffect(() => {
    dispatch(getReport({ startDate, endDate }));
  }, [dispatch, startDate, endDate]);

  const [colDefs, setColDefs] = useState([
    { field: 'idRemate', headerName: 'ID de Remate' },
    { field: 'inmobiliaria', headerName: 'Inmobiliaria' },
    { field: 'fecha', headerName: 'Fecha' },
    { field: 'descripcion', headerName: 'Descripcion' },
    {
      headerName: 'Adjudicados',
      children: [
        {
          headerName: 'Nombre Adjudicado',
          valueGetter: (params) => params.data.adjudicados[0]?.nombres || '',
        },
        {
          headerName: 'Apellido Adjudicado',
          valueGetter: (params) => params.data.adjudicados[0]?.apellidos || '',
        },
      ],
    },
  ]);

  const handleCancel = () => {
    console.log(startDate);
    console.log(endDate);
    console.log(report);
    showForm();
  };

  return (
    <div className="ag-theme-quartz" style={{ height: 500, width: 1202 }}>
      <Row>
        <Col>
          <Button variant="primary" onClick={handleCancel}>Cerrar</Button>
        </Col>
      </Row>
      <AgGridReact
        rowData={report || []}
        columnDefs={colDefs}
        rowSelection="single"
      />
    </div>
  );
}