import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useState, useRef, useCallback } from 'react';
import * as React from "react";
import { useDispatch, useSelector, useStore } from 'react-redux';
import { Button, Col, Row, FormLabel } from "react-bootstrap";
import { AgGridReact } from 'ag-grid-react'; // AG Grid Component
import "ag-grid-community/styles/ag-grid.css"; // Mandatory CSS required by the grid
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the grid
import { getAwarded, deleteAwarded } from '../../../redux/actions/actionAwarded';
import Swal from "sweetalert2";

export default function TableAwarded({ showForm, idUserEdit }) {

  const [userSelected, setUserSelected] = React.useState(false);
  const [selectedState, setSelectedState] = React.useState({});

  // Rellenar grid con datos
  const dispatch = useDispatch();
  const { awardeds } = useSelector((state) => state.getAwarded);


  // Obtener la id del usuario. 
  const [id, setId] = useState(0);
  const gridRef = useRef();
  const onSelectionChanged = useCallback(() => {
    const selectedRows = gridRef.current.api.getSelectedRows();
    document.querySelector("#selectedRows").innerHTML =
      selectedRows.length === 1 ? selectedRows[0].nombres : "";
    console.log(selectedRows[0].idAdjudicado);
    setId(selectedRows[0].idAdjudicado);
    console.log(id)

  }, []);



  useEffect(() => {
    dispatch(getAwarded());
    console.log(awardeds);
  }, [dispatch]);

  // Column Definitions: Defines the columns to be displayed.
  const [colDefs, setColDefs] = useState([
    { field: 'idAdjudicado', headerName: 'ID de Adjudicado' },
    { field: 'nombres', headerName: 'Nombre' },
    { field: 'apellidos', headerName: 'Apellidos' },
    { field: 'rfc', headerName: 'RFC' },
    { field: 'curp', headerName: 'CURP' },
    { field: 'telefono', headerName: 'Telefono' },
    { field: 'calle', headerName: 'Calle' },
    { field: 'num', headerName: 'Numero' },
    { field: 'colonia', headerName: 'Colonia' },
    { field: 'municipio', headerName: 'Municipio' },
    { field: 'estado', headerName: 'Estado' },
    { field: 'cp', headerName: 'Codigo Postal' },
    { field: 'semafonoEscrituracion', headerName: 'Semafono de Escrituracion' },
    { field: 'consideraciones', headerName: 'Consideraciones' },
    { field: 'estadoAdjudicacion', headerName: 'Estado de Adjudicacion' },
  ]);


  const handleNew = () => {
    showForm();
    idUserEdit(0);
  };

  // const handleEdit = () => {
  //   if (id) {
  //     idUserEdit(id);
  //     showForm();
  //   } else {
  //     alert('Seleccione un usuario para modificar');
  //   }
  // };

  const handleEdit = () => {
      console.log(id);
      if(id){
          showForm();
      }else{
          alert('Seleccione un usuario para modificar');
      }
  };

  const handleDelete = () => {

    if (id) {
      // Eliminar usuario seleccionado
      dispatch(deleteAwarded(id)).then(() => {
        Swal.fire({
          icon: "success",
          title: "Adjudicado eliminado",
          showConfirmButton: false,
          timer: 1500,
        }).then(() => {
          dispatch(getAwarded());
        });
      });
    } else {
      Swal.fire({
        icon: "error",
        title: "Error",
        text: "Seleccione un adjudicado para eliminar",
      });
      }
    // console.log(id);
    // if (id) {
    //   // Eliminar usuario seleccionado
    //   dispatch(deleteRealState(id))
    //     .then(() => {
    //       window.location.href = window.location.href;
    //     })
    // } else {
    //   alert("Seleccione un usuario para eliminar");
    // }
  };


  // ...

  return (

    // wrapping container with theme & size
    <div
      className="ag-theme-quartz" // applying the grid theme
      style={{ height: 500, width: 802 }} // the grid will fill the size of the parent container
    >
      <Row >
        <Col>
          <Button variant='primary' onClick={handleNew}>Nuevo Adjudicado</Button>
        </Col>
        <Col>
          <Button variant='warning' onClick={handleEdit}>Modificar Adjudicado</Button>
        </Col>
        <Col>
          <Button variant='danger' onClick={handleDelete}>Eliminar Adjudicado</Button>
        </Col>
      </Row>
      <div>
        <FormLabel>Adjudicado seleccionado: </FormLabel>
        <span id="selectedRows"></span>
      </div>
      <AgGridReact
        ref={gridRef}
        rowData={awardeds.response}
        columnDefs={colDefs}
        rowSelection={"single"}
        onSelectionChanged={onSelectionChanged}
      />
    </div>
  )
}

