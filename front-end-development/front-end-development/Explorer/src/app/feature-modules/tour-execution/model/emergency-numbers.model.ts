export interface EmergencyNumbers {
    disclaimer: string;
    error: string;
    data: {
      country: {
        name: string;
        ISOCode: string;
        ISONumeric: string;
      };
      ambulance: {
        all: string[];
        gsm: string | null;
        fixed: string | null;
      };
      fire: {
        all: string[];
        gsm: string | null;
        fixed: string | null;
      };
      police: {
        all: string[];
        gsm: string | null;
        fixed: string | null;
      };
      dispatch: {
        all: string[];
        gsm: string | null;
        fixed: string | null;
      };
      member_112: boolean;
      localOnly: boolean;
      nodata: boolean;
    };
  }
  