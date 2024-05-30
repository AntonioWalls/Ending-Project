import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useState, useRef, useCallback } from 'react';
import * as React from "react";
import { useDispatch, useSelector, useStore } from 'react-redux';
import { Button, Col, Row, FormLabel } from "react-bootstrap";
import { AgGridReact } from 'ag-grid-react'; // AG Grid Component
import "ag-grid-community/styles/ag-grid.css"; // Mandatory CSS required by the grid
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the grid
import { getRealState, deleteRealState } from '../../../redux/actions/ActionReal_State';
import Swal from "sweetalert2";

export default function TableReal_Estate({ showForm, idUserEdit }) {

  const [userSelected, setUserSelected] = React.useState(false);
  const [selectedState, setSelectedState] = React.useState({});

  // Rellenar grid con datos
  const dispatch = useDispatch();
  const { realstates } = useSelector((state) => state.getRealState);


  // Obtener la id del usuario. 
  const [id, setId] = useState(0);
  const gridRef = useRef();
  const onSelectionChanged = useCallback(() => {
    const selectedRows = gridRef.current.api.getSelectedRows();
    document.querySelector("#selectedRows").innerHTML =
      selectedRows.length === 1 ? selectedRows[0].razonSocial : "";

    setId(selectedRows[0].idInmobiliaria);
    console.log(id)

  }, []);



  useEffect(() => {
    dispatch(getRealState());
    console.log(realstates);
  }, [dispatch]);

  // Column Definitions: Defines the columns to be displayed.
  const [colDefs, setColDefs] = useState([
    { field: 'idInmobiliaria', headerName: 'ID de Inmobiliaria' },
    { field: 'razonSocial', headerName: 'Razon Social' },
    { field: 'rfc', headerName: 'RFC' },
    { field: 'telefono', headerName: 'Telefono' }
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
          idUserEdit(id);
          showForm();
      }else{
          alert('Seleccione un usuario para modificar');
      }
  };

  const handleDelete = () => {

    if (id) {
      // Eliminar usuario seleccionado
      dispatch(deleteRealState(id)).then(() => {
        Swal.fire({
          icon: "success",
          title: "Usuario eliminado",
          showConfirmButton: false,
          timer: 1500,
        }).then(() => {
          dispatch(getRealState());
        });
      });
    } else {
      Swal.fire({
        icon: "error",
        title: "Error",
        text: "Seleccione un usuario para eliminar",
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
          <Button variant='primary' onClick={handleNew}>Nueva Inmobiliaria</Button>
        </Col>
        <Col>
          <Button variant='warning' onClick={handleEdit}>Modificar Inmobiliaria</Button>
        </Col>
        <Col>
          <Button variant='danger' onClick={handleDelete}>Eliminar Inmobiliaria</Button>
        </Col>
      </Row>
      <div>
        <FormLabel>Inmobiliaria seleccionada: </FormLabel>
        <span id="selectedRows"></span>
      </div>
      <AgGridReact
        ref={gridRef}
        rowData={realstates.response}
        columnDefs={colDefs}
        rowSelection={"single"}
        onSelectionChanged={onSelectionChanged}
      />
    </div>
  )
}